using System.Threading.Tasks;
/// <summary>  
///     The requisition route will allow Schools to make requisitions, and other entities such as Subject Advisors to 
///     re-route requsitions and circuit managers to approve them.
/// </summary>
namespace DoE.Lsm.WF.Engine.Component.Requisition
{
    using Data.Repositories;
    using WF.Engine.Context;
    using WF.Component.Requisitions.Tasks;
    using Annotations;

    [FlowProcess(Name = "Quota.Requisitions")]
    public sealed class RequisitionMap : RouteFactory
    {
        private readonly  IRepositoryStore _repositoryStore;

        public RequisitionMap(IRepositoryStore repositoryStore)
        { _repositoryStore = repositoryStore; }


        ///<summary>  Go to <code> WF.Utils.Items.Utils.RequestRoute.TakeAsync </code> for more info on how this method works.
        ///
        /// <Exception> Any exception thrown from this methods will return as an Exec entry </Exception>
        ///</summary>
        public override async Task<ExecutionResult> TakeAsync(PayloadContext payload)
        {

            try
            {
                object obj = payload.Entity;
                var entity = obj as global::DoE.Lsm.Data.Repositories.EF.Requisition;  

                switch (payload.Role)
                {
                   case Role.School:
                        processOutcome = await SchoolTasks.RunTaskInstance(payload, _repositoryStore, entity);
                        break;

                    case Role.CircuitManager:
                        processOutcome = await CircuitManagerTasks.RunTaskInstance(payload, _repositoryStore, entity);
                        break;
                }

                return ExecutionResult.Success;
            }catch
            {
                return ExecutionResult.Failed;
            }
        }
    }
}