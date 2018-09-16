using System;
using System.Threading.Tasks;

namespace DoE.Lsm.WF.Component.Requisitions.Tasks
{

    using Resources;
    using Engine.Context;
    using Requisition.Tasks;
    using Data.Repositories;
    using Data.Repositories.EF;
    using Annotations.Exceptions;

    public class CircuitManagerTasks : JobInstance, IDisposable
    {

        //Gabbage Collection Objects...
        private static volatile CircuitManagerTasks _instance;
        private static readonly object _syncLock = new object();
        private bool _disposed = false;

        public CircuitManagerTasks(PortalLsm DbContext, Guid instanceId) : base(DbContext, instanceId) {}

        ///<summary> 
        ///     Assigns classes per role asynchronously
        ///</summary>
        public async static Task<JobInstance> RunTaskInstance(PayloadContext request, IRepositoryStoreRegistry repositoryContext, global::DoE.Lsm.Data.Repositories.EF.Requisition requisitionEntity)
        {

            if (_instance != null) return _instance;

                if (_instance == null)
                {
                    _instance = new CircuitManagerTasks(repositoryContext.Requisitions.DbContext, request.InstanceId);

                    switch (request.Response)
                    {
                        case Response.Discard:
                            return  await _instance.DiscardInstanceAsync(requisitionEntity, request , repositoryContext);

                        case Response.Approve:
                            break;
                    }

               }
            return _instance;
        }


        public async Task<CircuitManagerTasks> DiscardInstanceAsync(global::DoE.Lsm.Data.Repositories.EF.Requisition requisition, PayloadContext request, IRepositoryStoreRegistry RepositoryContext)
        {
            using (var transaction = EntityStore.Database.BeginTransaction())  
            {
                try
                {
                    var task = await new DiscardContext(requisition.InstanceId, RepositoryContext)
                        .Start(request, ReadMode.Clean)
                        .Park( Station.School_ReadOnly, State.Preamble, ReadMode.Clean)
                        .CreateFlowInstance(request, ReadMode.Clean)
                        .CreateStepInstanceAsync(request, ReadMode.Clean);

                     transaction.Commit();

                    return task as CircuitManagerTasks ;
                }
                catch
                {
                    transaction.Rollback();
                    throw new InvalidDatabaseOperationException("");
                }
            }
        }


        //   public async Task<int> SubmitRequisition<T>(DoE.Data.Repository.EF.Requisition requisition, WF.Scheme.WF task)
        //{

        //    //using (var trans = _LtsmDbContext.Requisitions.DbContext.da)
        //    //{
        //    try
        //    {
        //        var submitJob = await new Submit(requisition.ReqID, _LtsmDbContext)
        //            .ChangeState(Scheme.WF.Read.Clean)
        //            .CreateWFTicket(task)
        //            .CreateTLAsync(task, Scheme.WF.Read.Clean);

        //        //trans.Commit();
        //        return submitJob.job;
        //    }
        //    catch
        //    {
        //        //trans.Rollback();
        //        return -1;
        //    }
        //    // }
        //}

        /*          
           =============================================================================================================
           Generates a Transaction That Denies A Requisition     
           =============================================================================================================   

           This needs to be converted to async .I am having deadlock issues with dirty reads so I switched to commited reads which may send wrong row Id.

       */

        //public int ApproveRequisition(DoE.Data.Repository.EF.Requisition requisition, WF.Scheme.WF WFTask)
        //{

        //    //using (var trans = _LtsmDbContext.WF.DbContext.Database.BeginTransaction())
        //    //{

        //    try
        //    {

        //        var _rejectRequisitionJob = new RejectJob(requisition.ReqID, _LtsmDbContext)
        //            .ChangeState(Scheme.WF.Read.Clean)
        //            .CreateTL(WFTask, Scheme.WF.Read.Clean)
        //            .SaveMessage(WFTask, WFTask.CacheSlot01);

        //        //     trans.Commit();
        //    }
        //    catch (Exception e)
        //    {
        //        //   trans.Rollback();
        //        throw;
        //        //    }
        //    }
        //    return -1;
        //} //--> end ProcessSubmitAsync method


        //public async Task<int> ApproveRequisitionAsync(DoE.Data.Repository.EF.Requisition requisition, WF.Scheme.WF WFTask)
        //{
        //    //using (var trans = _LtsmDbContext.WF.DbContext.Database.BeginTransaction())
        //    //{
        //    try
        //    {
        //        var WFjob = await new Accept(requisition.ReqID, _LtsmDbContext)
        //           .ChangeStep(Scheme.WF.Read.Clean)
        //           .CreateTL(WFTask, Scheme.WF.Read.Clean)
        //           .GetWFItems()
        //           .ProcessWFItemsAsync();

        //        //        trans.Commit();
        //        //Create a notification ticket.
        //        return WFjob.job;
        //    }
        //    catch
        //    {
        //        //   trans.Rollback();
        //        throw;
        //        // }
        //    }
        //}

        public  PortalLsm EntityStore
        {
            get
            {
                return this._dataContext as PortalLsm;
            }
        }


        #region doCleanup
 
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
