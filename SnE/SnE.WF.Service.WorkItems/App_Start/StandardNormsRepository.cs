﻿using System;
using System.Threading.Tasks;

namespace DoE.Lsm.WF.WI.Config
{
    using Api;
    using Logger;
    using Security;
    using Context.Norms;
    using Service.WI.Proxies;
    using Data.Repositories;
    using SnE.WF.Service.Validation.Api;

    ///<summary>
    /// This can cause overheads when is loaded on every request.It should be loaded during start-up.(Currently its loaded by the Dependancy Injection container).
    ///<remark>This increases start-up time.</remark>
    ///</summary>
    public class StandardNormsRepository : IStandardNormsRepository
    {

        #region Constructor
        protected readonly IRepositoryStoreManager _repositoryManager;

        public StandardNormsRepository(ILogger logger, IRepositoryStoreManager repositoryManager, IValidationCallbacksContainer validationCallbacksContainer)
        {
                this._repositoryManager     = repositoryManager;
                CircuitManager              = new CircuitHandler(logger, repositoryManager);
                SubjectAnalyst              = new SubjectAnalystHandler(logger, repositoryManager);
                School                      = new School(logger, repositoryManager);
                ValidationCallbackContainer = validationCallbacksContainer;

                SetSuccessor<School, SubjectAnalystHandler>(School, SubjectAnalyst);
                SetSuccessor<SubjectAnalystHandler, CircuitHandler>(SubjectAnalyst, CircuitManager);     
        }
        #endregion

        public string ConsortiumGroupId                 { get; set; }
        public string Custordian                        { get; set; }
        public CircuitHandler CircuitManager            { get; set; }
        public School School                            { get; set; }
        public SubjectAnalystHandler SubjectAnalyst     { get; set; }
        public IValidationCallbacksContainer ValidationCallbackContainer { get; set; }

        public void SetSuccessor<T, T1>(Role predecessor, Role successor)
        {predecessor.SetSuccessor(successor);}                

        public TokenProvisionerModelProxy RegisterProcess(string processEntityType, string processSurveyKey, string claimsIdentity,  string interfaceKey , string norm)
        {
            if (string.IsNullOrEmpty(processEntityType)     || string.IsNullOrWhiteSpace(processEntityType)) throw new ArgumentNullException("processEntityType");
            if (string.IsNullOrEmpty(claimsIdentity)        || string.IsNullOrWhiteSpace(claimsIdentity))    throw new ArgumentNullException("claimsIdentity");
            if (string.IsNullOrEmpty(processSurveyKey)      || string.IsNullOrWhiteSpace(processSurveyKey))  throw new ArgumentNullException("processSurveyKey");
            if (string.IsNullOrEmpty(interfaceKey)          || string.IsNullOrWhiteSpace(interfaceKey))      throw new ArgumentNullException("interfaceKey");
            if (string.IsNullOrEmpty(norm)                  || string.IsNullOrWhiteSpace(norm))              throw new ArgumentNullException("norm");

            try
            {
                DateTime expryDate;
                string processInstanceId;

                _repositoryManager.Processes.CreateProcessInstance<TokenProvisionerModelProxy>(processEntityType, claimsIdentity, processSurveyKey, interfaceKey, norm, out expryDate, out processInstanceId);

                var token = PISecurityToken.Create(expryDate, processInstanceId, claimsIdentity);

                _repositoryManager.Processes.UpdateProcessToken<TokenProvisionerModelProxy>(Guid.Parse(processInstanceId), token);

                return new TokenProvisionerModelProxy {};
            }catch
            {
                throw;
            }
        }

        public async Task<ProcessRequestModelProxy> ProcessRequestStep(string requestToken, ProcessRequestModelProxy processRequestModel, IRequestPoolWorker processQueueWorker)
        {
            string processInstanceId = _repositoryManager.Processes.CheckProcessToken(requestToken);

            if (string.IsNullOrEmpty(processInstanceId)) throw new ArgumentNullException(nameof(requestToken));

            processRequestModel.SecurityToken = processInstanceId;

            return await processQueueWorker.QueueRequestsPool(processRequestModel, this);
        }
    }
}