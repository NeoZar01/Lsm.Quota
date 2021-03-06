﻿using System;
using System.Threading.Tasks;

namespace DoE.Lsm.WF.Component.Requisitions.Tasks
{

    using Resources;
    using Data.Repositories;
    using Data.Repositories.EF;
    using Annotations.Exceptions;
    using Requisition.Steps;
    using WI.Tools;

    //public class Custordian : ProcessInstance, IDisposable
    //{

    //    private static volatile Custordian _instance;
    //    private static readonly object _syncLock = new object();
    //    private bool _disposed = false;

    //    public Custordian(PortalLsm DbContext, Guid instanceId) : base(DbContext, instanceId) {}

    //    ///<summary> 
    //    ///     Assigns classes per role asynchronously
    //    ///</summary>
    //    public  static ProcessInstance RunTaskInstance(WorkInstance request, IRepositoryStoreManager repositoryContext, global::DoE.Lsm.Data.Repositories.EF.Requisition requisitionEntity)
    //    {

    //        if (_instance != null) return _instance;

    //            if (_instance == null)
    //            {
    //                _instance = new Custordian(repositoryContext.Requisitions.DbContext, new Guid(request.WIToken));

    //                switch (request.Response)
    //                {
    //                    case Response.Discard:
    //                        return   _instance.DiscardInstanceAsync(requisitionEntity, request , repositoryContext);

    //                    case Response.Approve:
    //                        break;
    //                }

    //           }
    //        return _instance;
    //    }


    //    public Custordian DiscardInstanceAsync(global::DoE.Lsm.Data.Repositories.EF.Requisition requisition, WorkInstance request, IRepositoryStoreManager RepositoryContext)
    //    {
    //        using (var transaction = EntityStore.Database.BeginTransaction())  
    //        {
    //            try
    //            {
    //                var task =  new DiscardContext(requisition.InstanceId, RepositoryContext)
    //                            .Start(request, ReadMode.Clean)
    //                            .Park( Station.School_ReadOnly, State.Preamble, ReadMode.Clean)
    //                            .CreateFlowInstance(request, ReadMode.Clean)
    //                            .CreateStepInstanceAsync(request, ReadMode.Clean);

    //                 transaction.Commit();

    //                return task;
    //            }
    //            catch
    //            {
    //                transaction.Rollback();
    //                throw new InvalidDatabaseOperationException("");
    //            }
    //        }
    //    }


    //    //   public async Task<int> SubmitRequisition<T>(DoE.Data.Repository.EF.Requisition requisition, WF.Scheme.WF task)
    //    //{

    //    //    //using (var trans = _LtsmDbContext.Requisitions.DbContext.da)
    //    //    //{
    //    //    try
    //    //    {
    //    //        var submitJob = await new Submit(requisition.ReqID, _LtsmDbContext)
    //    //            .ChangeState(Scheme.WF.Read.Clean)
    //    //            .CreateWFTicket(task)
    //    //            .CreateTLAsync(task, Scheme.WF.Read.Clean);

    //    //        //trans.Commit();
    //    //        return submitJob.job;
    //    //    }
    //    //    catch
    //    //    {
    //    //        //trans.Rollback();
    //    //        return -1;
    //    //    }
    //    //    // }
    //    //}

    //    /*          
    //       =============================================================================================================
    //       Generates a Transaction That Denies A Requisition     
    //       =============================================================================================================   

    //       This needs to be converted to async .I am having deadlock issues with dirty reads so I switched to commited reads which may send wrong row Id.

    //   */

    //    //public int ApproveRequisition(DoE.Data.Repository.EF.Requisition requisition, WF.Scheme.WF WFTask)
    //    //{

    //    //    //using (var trans = _LtsmDbContext.WF.DbContext.Database.BeginTransaction())
    //    //    //{

    //    //    try
    //    //    {

    //    //        var _rejectRequisitionJob = new RejectJob(requisition.ReqID, _LtsmDbContext)
    //    //            .ChangeState(Scheme.WF.Read.Clean)
    //    //            .CreateTL(WFTask, Scheme.WF.Read.Clean)
    //    //            .SaveMessage(WFTask, WFTask.CacheSlot01);

    //    //        //     trans.Commit();
    //    //    }
    //    //    catch (Exception e)
    //    //    {
    //    //        //   trans.Rollback();
    //    //        throw;
    //    //        //    }
    //    //    }
    //    //    return -1;
    //    //} //--> end ProcessSubmitAsync method


    //    //public async Task<int> ApproveRequisitionAsync(DoE.Data.Repository.EF.Requisition requisition, WF.Scheme.WF WFTask)
    //    //{
    //    //    //using (var trans = _LtsmDbContext.WF.DbContext.Database.BeginTransaction())
    //    //    //{
    //    //    try
    //    //    {
    //    //        var WFjob = await new Accept(requisition.ReqID, _LtsmDbContext)
    //    //           .ChangeStep(Scheme.WF.Read.Clean)
    //    //           .CreateTL(WFTask, Scheme.WF.Read.Clean)
    //    //           .GetWFItems()
    //    //           .ProcessWFItemsAsync();

    //    //        //        trans.Commit();
    //    //        //Create a notification ticket.
    //    //        return WFjob.job;
    //    //    }
    //    //    catch
    //    //    {
    //    //        //   trans.Rollback();
    //    //        throw;
    //    //        // }
    //    //    }
    //    //}

    //    public  PortalLsm EntityStore
    //    {
    //        get
    //        {
    //            return this._dataContext as PortalLsm;
    //        }
    //    }


    //    #region doCleanup
 
    //    public void Dispose()
    //    {
    //        Dispose(true);

    //        GC.SuppressFinalize(this);
    //    }

    //    public void Dispose(bool disposing)
    //    {
    //        if (_disposed) return;

    //        if (disposing)
    //        {
    //            _instance = null;
    //        }
    //    }

    //    #endregion

    //}
}
