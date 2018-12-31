
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DoE.Lsm.WF.WI.Api
{

    using Context.Norms;
    using System.Threading.Tasks;
    using Service.WI.Proxies;
    using SnE.WF.Service.Validation.Api;

    public interface IStandardNormsRepository
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="T1"></typeparam>
        /// <param name="predecessor"></param>
        /// <param name="successor"></param>
        void SetSuccessor<T, T1>(Role predecessor, Role successor);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="processEntityType"></param>
        /// <param name="processSurveyKey"></param>
        /// <param name="claimsIdentity"></param>
        /// <param name="interfaceKey"></param>
        /// <param name="norm"></param>
        /// <returns></returns>
        TokenProvisionerModelProxy RegisterProcess(string processEntityType, string processSurveyKey, string claimsIdentity, string interfaceKey, string norm);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="requestToken"></param>
        /// <param name="processRequestModel"></param>
        /// <param name="processQueueWorker"></param>
        /// <returns></returns>
        Task<ProcessRequestModelProxy> ProcessRequestStep(string requestToken, ProcessRequestModelProxy processRequestModel, IRequestPoolWorker processQueueWorker);

        string ConsortiumGroupId                { get; set; }
        string Custordian                       { get; set; }
        CircuitHandler CircuitManager           { get; set; }
        School School                           { get; set; }
        SubjectAnalystHandler SubjectAnalyst    { get; set; }

        IValidationCallbacksContainer ValidationCallbackContainer { get; set; }
    }
}