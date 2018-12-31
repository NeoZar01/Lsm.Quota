using System;
using System.Threading.Tasks;

namespace DoE.Lsm.WF.Component.Requisition.Steps
{
    //using Engine.Context;
    //using Data.Repositories;
    //using Annotations.Exceptions;
    //using Requisitions.Factories;
    //using Engine.WI.Tools;

    //public partial class DiscardContext : DiscardFactory
    //{

    //    public DiscardContext(Guid instanceId, IRepositoryStoreManager store) : base(instanceId, store) {}



    //    /// <summary>
    //    /// 
    //    /// </summary>
    //    /// <param name="station"></param>
    //    /// <param name="state"></param>
    //    /// <param name="readMode"></param>
    //    /// <returns></returns>
    //    public override DiscardFactory Park(string station, string state, ReadMode readMode)
    //    {

    //       var task =  _repositoryStore.Requisitions.Park(_repositoryStore.Requisitions.FindByInstanceId(_instanceId), station, state);

    //        if(task == ExecutionResult.Success)
    //        {
    //            return this;
    //        }
    //        throw new InvalidDatabaseOperationException("");
    //    }



    //    public override Task<ProcessInstance> ParkAsync(string station,string state, ReadMode readType)
    //    {

    //        var result = _repositoryStore.Requisitions.Park(_repositoryStore.Requisitions.FindByInstanceId(_instanceId), station, state);

    //        //if (result == ExecutionResult.Success)
    //        //{
    //        //    return Task.FromResult();
    //        //}
    //        throw new InvalidDatabaseOperationException("Async :: There was an error processing your request. The Workflow engine failed to move to another step");
    //    }


  
    //    public override async Task<ProcessInstance> CreateStepInstanceAsync(WorkInstance request, ReadMode readType)
    //    {

    //        //var asynctask = _DbRepositories.WF.CreateStepInstanceAsync( );

    //        //if (asynctask == WITask.Succeeded )
    //        //{
    //        //    job = 1;
    //        //    return this;
    //        //}

    //        var testToken = 5;

    //        await Task.FromResult(testToken);

    //        throw new InvalidDatabaseOperationException();
    //    }

    //    public override DiscardFactory CreateFlowInstance(WorkInstance request, ReadMode readType)
    //    {

    //        //var WFRequisition = WF_DbContext.WF.GetWFByRequisition(requisition);

    //        //if (WFRequisition == null)
    //        //{

    //        //    #region  #This Region Creates a WorkFlow For thrown Requisition
    //        //    WF WorkFlow = (w) =>
    //        //    {
    //        //        return new DoE.Data.Repository.EF.WorkFlow
    //        //        {
    //        //            CreationDate = DateTime.Now,
    //        //            From = w.Sender,
    //        //            FromDescription = w.SenderName,
    //        //            IsActive = true,
    //        //            IsApproved = false,
    //        //            LastModifiedDate = DateTime.Now,
    //        //            Ref = requisition,
    //        //            To = w.Receiver,
    //        //            ToDescription = w.ReceiverName
    //        //        };
    //        //    };
    //        //    #endregion

    //        //    var WFRequisitionTask = WF_DbContext.WF.SaveWF(WorkFlow(task), Schema.Request.Read.Clean);

    //        //    if(WFRequisitionTask == null)
    //        //    {
    //        //        throw new Education.Repository.Exceptions.InstanceNotFoundException();
    //        //    }
    //        //    WFId = WFRequisitionTask.id;
    //        //    return this;
    //        //}

    //        //    WFId = WFRequisition.id;
    //            return this;
    //    }


    //    /// <summary>
    //    /// 
    //    /// </summary>
    //    /// <param name="payload"></param>
    //    /// <param name="TransactionRead"></param>
    //    /// <returns></returns>
    //    public override DiscardFactory Start(WorkInstance payload, ReadMode TransactionRead)
    //    {
    //         return this;
    //    }
    //}


    //#region Unused Imports
    //public partial class DiscardContext
    //{
    //    public override Task<ProcessInstance> CreateFlowInstanceAsync(WorkInstance request, ReadMode readType)
    //    {
    //        throw new NotImplementedException();
    //    }
    //    public override DiscardFactory CreateStepInstance(WorkInstance request, ReadMode readType)
    //    {
    //        throw new NotImplementedException();
    //    }

    //}
    //#endregion


}
