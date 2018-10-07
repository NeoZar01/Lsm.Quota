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
    using WF.Component.Requisitions;
    using WF.Component.Requisitions.Tasks;

    [FlowProcess(Name = "Quota.Requisitions")]
    public sealed class RequisitionStore : RouteFactory
    {
        private readonly  IRepositoryStoreRegistry _repositoryStore;

        public RequisitionStore(IRepositoryStoreRegistry repositoryStore)
        { _repositoryStore = repositoryStore; }


        ///<summary>  Go to <code> WF.Utils.Items.Utils.RequestRoute.TakeAsync </code> for more info on how this method works.
        ///
        /// <Exception> Any exception thrown from this methods will return as an Exec entry </Exception>
        ///</summary>
        public override async Task<ExecutionResult> TakeAsync(PayloadContext payload)
        {

            try
            {
                object obj = payload.EntityType;
                var entity = obj as Requisition;

                if (payload.Role.Equals(Role.School))
                {
                    processOutcome = await SchoolJobs.RunTaskInstance(payload, _repositoryStore, entity);
                }
                else if (payload.Role.Equals(Role.CircuitManager))
                {
                    processOutcome = await CircuitManagerTasks.RunTaskInstance(payload, _repositoryStore, entity);
                }
                else
                {
                    processOutcome = await CircuitManagerTasks.RunTaskInstance(payload, _repositoryStore, entity);
                }
                return ExecutionResult.Success;
            }catch
            {
                return ExecutionResult.Failed;
            }
        }
    }
}