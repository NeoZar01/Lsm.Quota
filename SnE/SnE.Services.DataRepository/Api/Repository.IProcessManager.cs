namespace DoE.Lsm.Data.Repositories.Workflow.Engine
{
    using Annotations;
    using EF;
    using System;
    using System.Threading.Tasks;

    public interface IProcessManager : IRepository<WIProcessInstance>
    {
        
        /// <summary>
        ///    Creates a new process instance and returns variables for creating a process token
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entityType"></param>
        /// <param name="claimsIdentity"></param>
        /// <param name="surveyKey"></param>
        /// <param name="interfaceKey"></param>
        /// <param name="expiryDateKey"></param>
        /// <param name="expiryDate"></param>
        /// <param name="processInstanceId"></param>
        /// <returns></returns>
        [InstanceType("Lsm.Requisitions , Lsm.Orders")]
        void CreateProcessInstance<T>(string entityType, string claimsIdentity, string surveyKey, string interfaceKey, string expiryDateKey, out DateTime expiryDate, out string processInstanceId) where T : class;

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="processInstanceId"></param>
        /// <param name="token"></param>
        void UpdateProcessToken<T>(Guid processInstanceId , string token) where T : class;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="expiryDateKey"></param>
        /// <param name="interfaceKey"></param>
        /// <param name="surveyKey"></param>
        /// <returns></returns>
        void ConfigureExpiryDate(string expiryDateKey , string interfaceKey , string surveyKey , out DateTime expiryDate);

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="model"></param>
        /// <param name="currentStepInstanceId"></param>
        /// <param name="preceedingStepId"></param>
        /// <param name="preceedingStepInstanceId"></param>
        /// <param name="UserToken"></param>
        /// <param name="InstanceCaseId"></param>
        /// <param name="instanceEntityType"></param>
        /// <param name="parameters"></param>
        void CreateInstanceSnapShot<T>(T model, string currentStepInstanceId, string preceedingStepId, string preceedingStepInstanceId, string UserToken, string InstanceCaseId, string instanceEntityType, params string[] parameters) where T : class;


        /// <summary>
        /// 
        /// </summary>
        /// <param name="entityType"></param>
        /// <param name="settings"></param>
        void InstallRules(string entityType, int[] settings);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="processInstanceInputToken"></param>
        /// <param name="processInstanceOutputToken"></param>
        /// <returns></returns>
        string ResolveProcessInstance(string processInstanceInputToken, out string processInstanceOutputToken);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="requestToken"></param>
        /// <returns></returns>
        string CheckProcessToken(string requestToken);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="instanceCaseId"></param>
        /// <param name="precedingStepId"></param>
        /// <param name="precedingStepInstanceId"></param>
        void SetupProcessStep(string instanceCaseId, out string precedingStepId, out string precedingStepInstanceId);

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="flowId"></param>
        ///// <param name="entityType"></param>
        ///// <param name="entityId"></param>
        ///// <param name="creator"></param>
        ///// <param name="recepient"></param>
        ///// <param name="state"></param>
        ///// <returns></returns>
        //[InstanceType("Lsm.Requisitions , Lsm.Orders")]
        //string CreateStepInstance(string flowId, string entityType, string entityId, string creator, string recepient ,  string completionDateVariable, string completionDateSubVariable, string state, string outcome);

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="flowId"></param>
        ///// <param name="entityType"></param>
        ///// <param name="entityId"></param>
        ///// <param name="creator"></param>
        ///// <param name="recepient"></param>
        ///// <param name="state"></param>
        ///// <returns></returns>
        //[InstanceType("Lsm.Requisitions , Lsm.Orders")]
        //Task<string> CreateStepInstanceAsync(string flowId, string entityType, string entityId, string creator, string recepient, string completionDateVariable, string completionDateSubVariable, string state, string outcome);



        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="precedingStepId"></param>
        ///// <param name="precedingStepInstanceId"></param>
        //void ConfigureInstancePreceedingStep(string precedingStepId, out string precedingStepInstanceId);



    }
}