using System;
using System.Threading.Tasks;
/// <summary>  
///     The requisition route will allow Schools to make requisitions, and other entities such as Subject Advisors to 
///     re-route requsitions and circuit managers to approve them.
/// </summary>
namespace DoE.Lsm.WF.Engine.Component.Requisition
{
    using Context;
    using Annotations;
    using Data.Repositories;
    using Data.Repositories.EF;
    using WF.Component.Requisitions.Tasks;

    using static WF.Component.Requisitions.Role;

    [FlowProcess(Name = "Lsm.Requistions.QOT")]
    public class RequisitionsProcess : GenericProcessFactory , RouteFactory
    {
        protected ProcessInstance processOutcome;

        protected readonly IRepositoryStoreManager   _repositoryStore;

        public RequisitionsProcess(IRepositoryStoreManager repositoryStore)
        { _repositoryStore = repositoryStore; }


        ///<summary>  Go to <code> WF.Utils.Items.Utils.RequestRoute.Initiate </code> for more info on how this method works.
        ///
        /// <Exception> Any exception thrown from this methods will return as an Exec entry </Exception>
        ///</summary>        
        public async Task<ExecutionResult> Initiate(ProcessCase payload)
        {
            try
            {
                object obj = payload.EntityType;
                var entity = obj as Requisition;

                if (payload.Role.Equals(CTDN))
                {
                    processOutcome = await Servicer.RunTaskInstance(payload, _repositoryStore, entity);
                }
                else if (payload.Role.Equals(CTDN))
                {
                    processOutcome = await Custordian.RunTaskInstance(payload, _repositoryStore, entity);
                }
                else
                {
                    processOutcome = await Custordian.RunTaskInstance(payload, _repositoryStore, entity);
                    return ExecutionResult.Idle;
                }
                return ExecutionResult.Success;
            }catch
            {
                return ExecutionResult.Failed;
            }
        }




    }
}