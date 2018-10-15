using System;
using System.ServiceModel.Activation;

namespace DoE.Lsm.WF.Engine
{
    using Api;
    using Logger;
    using Context;
    using Svc.Context;
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="payload"></param>
        /// <returns></returns>
        //public string BeginProcessRequest(CaseToken payload)
        //{
        //    return Remote.CallMemberAsync(payload).Status;
        //}

        public IAsyncResult BeginProcessRequest(ProcessCase context, AsyncCallback callback, object state)
        {
//            return new CompletedAsyncResult<CaseToken>(context);
            throw new Exception();
        }

        public ProcessCase EndProcessRequest(ProcessCase context)
        {
            throw new NotImplementedException();
        }
    }
}