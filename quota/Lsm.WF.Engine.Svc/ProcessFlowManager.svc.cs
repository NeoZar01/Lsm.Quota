using System;
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
        public ProcessFlowManager(ILogger genericLogger ,  IRepositoryStoreManager dataStoreManager )
        {
            this._genericLogger     = genericLogger.InitiateAlertInstance;
            this._dataStoreManager  = dataStoreManager;
        }

        public IAsyncResult BeginProcessRequestXml(ProcessWorkItem payload, AsyncCallback callback, object state)
        {
            var processOutcome  = RemoteProcessInvoker.Method(payload).Status;

            //            return new CompletedAsyncResult<CaseToken>(context);
            throw new Exception();
        }

        public ProcessWorkItem EndProcessRequestXml(ProcessWorkItem context)
        {
            throw new NotImplementedException();
        }

        public IAsyncResult BeginProcessRequestJson(ProcessWorkItem payload, AsyncCallback callback, object state)
        {
            throw new NotImplementedException();
        }

        public ProcessWorkItem EndProcessRequestJson(ProcessWorkItem context)
        {
            throw new NotImplementedException();
        }
    }
}