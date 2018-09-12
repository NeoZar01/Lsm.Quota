using System;
using System.Threading.Tasks;

namespace DoE.Lsm.WF.Component.Requisitions.Tasks
{
    using Resources;
    using Annotations.Exceptions;
    using Engine.Context;
    using Data.Repositories.EF;
    using Data.Repositories;
    using Monitor.Annotations;
    using Requisition.Tasks;

    public sealed class SchoolTasks : JobInstance, IDisposable
    {

        private static volatile SchoolTasks _instance;
        private static readonly object _syncLock = new object();
        private bool _disposed = false;

        public SchoolTasks(PortalLsm DbContext , Guid instanceId) : base(DbContext, instanceId)
        {}

        public PortalLsm EntityStore
        {
            get
            {
                return this._dataContext as PortalLsm;
            }
        }

        public void Dispose()
        {
            Dispose(true);

            GC.SuppressFinalize(this);
        }

        public void Dispose(bool disposing)
        {
            if (_disposed) return;

            if (disposing)
            {
                _instance = null;
            }
        }

        /// <summary>
        ///         Returns every job as an instance
        /// </summary>
        /// <param name="payload"></param>
        /// <param name="repositoryContext"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async static Task<JobInstance> RunTaskInstance(PayloadContext payload, IRepositoryStore repositoryContext, global::DoE.Lsm.Data.Repositories.EF.Requisition entity)
        {

            if (_instance != null) return await Task.FromResult(_instance);

            if (_instance == null)
            {
                _instance = new SchoolTasks(repositoryContext.Requisitions.DbContext, payload.InstanceId);

                switch (payload.Response)
                {
                    case Response.Discard:
                        return await _instance.PreambleRequisition(entity, payload, repositoryContext);

                    case Response.Approve:
                        break;
                }

            }
            return _instance;
        }

        /// <summary>
        ///         Adds a new book to the shopping card without the intention of creating a new requisition.
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="payload"></param>
        /// <param name="store"></param>
        /// <exception cref="ArgumentNullException">Handles null parameter values</exception>
        /// <returns></returns>
        [Check(listener: "AsyncListener", estimatedExecutionTimeInMinutes: 2)]
        [Watch(For: typeof(FailedTransactionException), code: 10056,  exception: "There was an error preambling your item.Please contact technical support for this issue.")]
        public async Task<JobInstance> PreambleRequisition(Requisition entity, PayloadContext payload, IRepositoryStore store)
        {

            if (entity  == null)    throw new ArgumentNullException(nameof(entity));
            if (payload == null)    throw new ArgumentNullException(nameof(payload));
            if (store   == null)    throw new ArgumentNullException(nameof(store));

            using (var transaction = EntityStore.Database.BeginTransaction())  //opens a transaction.
            {
                try
                {
                    var task = await new DiscardContext(entity.InstanceId, store)
                          .Park( Station.School_ReadOnly, State.Preamble, ReadMode.Clean)            //Park your requisition in a preamble state.
                          .CreateFlowInstanceAsync(payload, ReadMode.Clean) as SchoolTasks;

                    transaction.Commit();
                    return Process.From(task,  outcome: "SUCCESS");
                }
                catch
                {
                    transaction.Rollback();
                    throw new FailedTransactionException("Failed to run transaction");
                }
            }
        }
    }
}