using System;
using System.Threading.Tasks;
/// <summary>  
///     The requisition route will allow Schools to make requisitions, and other entities such as Subject Advisors to 
///     re-route requsitions and circuit managers to approve them.
/// </summary>
namespace DoE.Lsm.WF.Engine.Component.Requisition
{
    using Context;
    using WI.Tools;
    using Annotations;
    using Data.Repositories;
    using Annotations.Exceptions;

    using static WF.Component.Requisitions.Role;

    [FlowProcess(Name = "SNE.Lsm.Requisitions")]
    public class RequisitionsProcess : GenericStepInstanceFactory , RouteFactory
    {
        protected ProcessInstance processOutcome;

        protected readonly IRepositoryStoreManager   _dataStoreManager;

        public RequisitionsProcess(IRepositoryStoreManager dataStoreManager)
        { _dataStoreManager = dataStoreManager; }

        [Watch(For: typeof(InvalidDatabaseOperationException), code: 1055, exception: "There was an error processing your workflow step instance.Please contact technical support for this issue.")]
        public async Task<ExecutionResult> InitiateStepInstance(ProcessWorkItem payload)
        {
            try
            {
                var outcome = await PreConfig(payload.ProcessInstanceId, this._dataStoreManager, null)
                                   .Start(payload, this._dataStoreManager)
                                   .Instantiate()                                        
                                   .End();                            
            }
            catch
            {
                throw;
            }
            return ExecutionResult.Success;                      
       }
    }
}


///<summary>  Go to <code> WF.Utils.Items.Utils.RequestRoute.Initiate </code> for more info on how this method works.
///
/// <Exception> Any exception thrown from this methods will return as an Exec entry </Exception>
///</summary>        
///

//public override StepFactory Run(InstanceCase payload)
////{
////     try
////    {
////        object obj = payload.EntityType;
////        var entity = obj as Requisition;

////        if (payload.Role.Equals(SHL))
////        {
////            processOutcome = await Servicer.RunTaskInstance(payload, _repositoryStore, entity);
////        }
////        else if (payload.Role.Equals(CTDN))
////        {
////            processOutcome = await Custordian.RunTaskInstance(payload, _repositoryStore, entity);
////        }
////        else
////        {
////            processOutcome = await Custordian.RunTaskInstance(payload, _repositoryStore, entity);
////            return ExecutionResult.Idle;
////        }
////        return ExecutionResult.Success;
////    }
////    catch
////    {
////        return ExecutionResult.Failed;
////    }

//    return base.Run(payload);
//}
