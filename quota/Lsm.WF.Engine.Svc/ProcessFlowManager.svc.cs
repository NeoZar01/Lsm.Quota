using System;
using System.Runtime;
using System.ServiceModel.Activation;

namespace DoE.Lsm.WF.Engine
{
    using Api;
    using Logger;
    using Context;
    using Data.Repositories;

    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class ProcessFlowManager : IProcessFlowManager
    {
        protected readonly ILogger _genericLogger;
        protected readonly IRepositoryStoreManager _dataStoreManager;
        public ProcessFlowManager(ILogger genericLogger ,  IRepositoryStoreManager dataStoreManager)
        {
            this._genericLogger     = genericLogger.InitiateAlertInstance;
            this._dataStoreManager  = dataStoreManager;
        }

        public IAsyncResult BeginProcessRequest(ProcessWorkItem payload, AsyncCallback callback, object state)
        {
             var token  = RemoteProcessWorker.Method(payload);
             throw new ApplicationException();
             //return new CompletedAsyncResult<ProcessWorkItem>(token);
        }

        public ProcessWorkItem EndProcessRequest(IAsyncResult result)
        {
            throw new NotImplementedException();
        }
    }
}