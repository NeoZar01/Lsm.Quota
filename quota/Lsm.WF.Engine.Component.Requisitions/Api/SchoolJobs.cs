using System;
using System.Threading.Tasks;

namespace DoE.Lsm.WF.Component.Requisitions.Tasks
{
    using Resources;
    using Engine.Context;
    using Data.Repositories.EF;
    using Data.Repositories;
    using Monitor.Annotations;
    using Requisition.Tasks;
    using Annotations.Exceptions;
    using Engine.Component.Monitor.Api;
    using Annotations.Api.Exceptions;

    public sealed class SchoolJobs : JobInstance, IDisposable
    {
        private static readonly object _syncLock = new object();

        /// <summary>
        ///         Returns every job as an instance
        /// </summary>
        /// <param name="payload"></param>
        /// <param name="repositoryContext"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async static Task<JobInstance> RunTaskInstance(PayloadContext payload, IRepositoryStoreRegistry repositoryContext, global::DoE.Lsm.Data.Repositories.EF.Requisition entity)
        {

            if (_instance != null) return await Task.FromResult(_instance);

            if (_instance == null)
            {
                _instance = new SchoolJobs(repositoryContext.Requisitions.DbContext, payload.ComToken);

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
        /// <param name="dbStore"></param>
        /// <exception cref="ArgumentNullException">Handles null parameter values</exception>
        /// <returns></returns>
        [Trace(listener: "AsyncListener", estimatedExecutionTimeInMinutes: 2)]
        public async Task<JobInstance> PreambleRequisition(Requisition entity, PayloadContext payload, IRepositoryStoreRegistry dbStore)
        {
            if (entity    == null)      throw new ArgumentNullException(nameof(entity));
            if (payload   == null)      throw new ArgumentNullException(nameof(payload));
            if (dbStore   == null)      throw new ArgumentNullException(nameof(dbStore));

            using (var transaction = TransactionChannel.Database.BeginTransaction())  //opens a transaction.
            {
                try
                {
                    using (var instanceLock = new Lock(dbStore, "9_RQST_QTA", entity.InstanceId.ToString(), payload.IdentityToken))
                    {
                        var task = await new DiscardContext(entity.InstanceId, dbStore)
                                    .Start(payload, ReadMode.Clean)
                                    .Park(Station.School_ReadOnly, State.Preamble, ReadMode.Clean)            //Park your requisition in a preamble state.
                                    .CreateFlowInstanceAsync(payload, ReadMode.Clean) as SchoolJobs;

                        transaction.Commit();
                        return Process.From(task, outcome: "SUCCESS");
                    }
                }
                catch(UIException e)
                {
                    transaction.Rollback();
                    throw new UIException(e.StackTrace);
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    throw new UIException(e.StackTrace);
                }
            }
        }

        /// <summary>
        ///     Class the repository db context to open a transaction channel
        /// </summary>
        public PortalLsm TransactionChannel
        { get { return this._dataContext as PortalLsm; } }

        public SchoolJobs(PortalLsm DbContext, Guid instanceId) : base(DbContext, instanceId)
        { }

        #region doGabbageCleanup
        private static volatile SchoolJobs _instance;

        private bool _disposed = false;

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

        #endregion

    }
}