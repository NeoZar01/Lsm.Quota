using System;
using System.Runtime;
using System.ServiceModel.Activation;

namespace DoE.Lsm.WF.Engine
{
    using Api;
    using Core;
    using Logger;
    using WI.Api;
    using WI.Context.Norms;
    using Data.Repositories;
    using System.Threading.Tasks;
    using WI.Models;

    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class WINorm : IWI
    {
        protected readonly ILogger                   _logger;
        protected readonly IRepositoryStoreManager   _dataStoreManager;
        protected readonly INormInstanceHandler      _WIHandler;
        protected readonly IPayloadTrafficer         _payloadTrafficer;
        protected readonly IActionTaskFactory        _actionManager;

        public WINorm(ILogger genericLogger ,  IRepositoryStoreManager dataStoreManager , INormInstanceHandler WIHandler, IPayloadTrafficer payloadTrafficer, IActionTaskFactory actionManager)
        {
            this._logger     = genericLogger.InitiateAlertInstance;
            this._dataStoreManager  = dataStoreManager;
            this._WIHandler         = WIHandler;
            this._payloadTrafficer  = payloadTrafficer;
            this._actionManager     = actionManager;    
        }

        /// <summary>
        ///         Handles the Process Request Token and returns 
        /// </summary>
        /// <param name="payload"></param>
        /// <param name="callback"></param>
        /// <param name="state"></param>
        /// <returns></returns>
        public IAsyncResult BeginProcessRequest(WorkItemInstance payload, AsyncCallback callback, object state)
        {
    //            return new CompletedAsyncResult<WorkItemInstance>(_WIHandler.ConvertToNormProcess<Norm>(payload)); //Determines which process the token belongs to and returns a norm
                throw new ApplicationException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        public async Task<WorkItemInstance> EndProcessRequest(Norm payload, IAsyncResult result)
        {
            return await _WIHandler.ProcessNormInstanceRequest(payload , _payloadTrafficer, _logger, _dataStoreManager, _actionManager);
        }
    }
}