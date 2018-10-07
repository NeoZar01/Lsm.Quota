namespace DoE.Lsm.Data.Repositories.Workflow.Engine
{
    using DoE.Lsm.Annotations;
    using EF;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IProcessManager : IRepository<WFProcessInstance>
    {

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entityType"></param>
        /// <param name="entityId"></param>
        /// <param name="createdby"></param>
        /// <param name="state"></param>
        /// <returns></returns>
        string CreateFlowInstance<T>([InstanceType("QUOTA.REQUISITION")]string entityType, string entityId, string createdby, string completionDateVariable, string completionDateSubVariable, string state, string outcome) where T : class;

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entityType"></param>
        /// <param name="entityId"></param>
        /// <param name="createdby"></param>
        /// <param name="state"></param>
        /// <returns></returns>
        Task<string> CreateFlowInstanceAsync<T>([InstanceType("QUOTA.REQUISITION")]string entityType, string entityId, string createdby, string completionDateVariable, string completionDateSubVariable, string state, string outcome) where T : class;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="flowId"></param>
        /// <param name="entityType"></param>
        /// <param name="entityId"></param>
        /// <param name="creator"></param>
        /// <param name="recepient"></param>
        /// <param name="state"></param>
        /// <returns></returns>
        string CreateStepInstance([InstanceType("QUOTA.REQUISITION")]string flowId, string entityType, string entityId, string creator, string recepient ,  string completionDateVariable, string completionDateSubVariable, string state, string outcome);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="flowId"></param>
        /// <param name="entityType"></param>
        /// <param name="entityId"></param>
        /// <param name="creator"></param>
        /// <param name="recepient"></param>
        /// <param name="state"></param>
        /// <returns></returns>
        Task<string> CreateStepInstanceAsync([InstanceType("QUOTA.REQUISITION")]string flowId, string entityType, string entityId, string creator, string recepient, string completionDateVariable, string completionDateSubVariable, string state, string outcome);
    }
}