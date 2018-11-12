namespace DoE.Lsm.Data.Repositories.Workflow.Engine
{
    using DoE.Lsm.Annotations;
    using EF;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IProcessManager : IRepository<WIProcessInstance>
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
        string CreateProcessInstance<T>([InstanceType("SNE_REQUISITION")]string entityType, string entityId, string createdby, string completionDateVariable, string completionDateSubVariable, string state, string outcome) where T : class;

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entityType"></param>
        /// <param name="entityId"></param>
        /// <param name="createdby"></param>
        /// <param name="state"></param>
        /// <returns></returns>
        Task<string> CreateProcessInstanceAsync<T>([InstanceType("SNE_REQUISITION")]string entityType, string entityId, string createdby, string completionDateVariable, string completionDateSubVariable, string state, string outcome) where T : class;

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
        string CreateStepInstance([InstanceType("SNE_REQUISITION")]string flowId, string entityType, string entityId, string creator, string recepient ,  string completionDateVariable, string completionDateSubVariable, string state, string outcome);

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
        Task<string> CreateStepInstanceAsync([InstanceType("SNE_REQUISITION")]string flowId, string entityType, string entityId, string creator, string recepient, string completionDateVariable, string completionDateSubVariable, string state, string outcome);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="instanceCaseId"></param>
        /// <param name="precedingStepId"></param>
        /// <param name="precedingStepInstanceId"></param>
        void ProcessInstanceParkingStep(string instanceCaseId ,out string precedingStepId ,out string precedingStepInstanceId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="precedingStepId"></param>
        /// <param name="precedingStepInstanceId"></param>
        void ConfigureInstancePreceedingStep(string precedingStepId, out string precedingStepInstanceId);

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="payload"></param>
        /// <param name="currentStepInstanceId"></param>
        /// <param name="preceedingStepId"></param>
        /// <param name="preceedingStepInstanceId"></param>
        /// <param name="UserToken"></param>
        /// <param name="InstanceCaseId"></param>
        /// <param name="instanceEntityType"></param>
        /// <param name="parameters"> This can only be up to 10 at the moment</param>
        void CreateInstanceSnapShot<T>(T payload, string currentStepInstanceId, string preceedingStepId, string preceedingStepInstanceId, string UserToken, string InstanceCaseId, string instanceEntityType , params string[] parameters) where T : class;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entityType"></param>
        /// <param name="settings"></param>
        void InstallRules(string entityType, int[] settings);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="processHash"></param>
        /// <param name="processInstanceHash"></param>
        /// <returns></returns>
        string ResolveProcessInstance(string processInstanceInputHash , out string processInstanceOutputHash);
    }
}