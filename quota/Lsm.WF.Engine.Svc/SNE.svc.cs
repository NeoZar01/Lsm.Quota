using System;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Threading.Tasks;

using System.ServiceModel.Activation;

namespace DoE.Lsm.WF.Service.Web
{
    using Logger;
    using Data.Repositories;
    using WF.Web.Models;
    using WF.WI.Api;
    using Contracts;
    using Models;
    using WI.Proxies;
    using SnE.WF.Service.Validation.Api;

    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class WINorm : IWI
    {
        protected readonly ILogger                      _loggerHandler;
        protected readonly IRepositoryStoreManager      _repositoryManagerHandler;
        protected readonly INormsStandardManager        _normsStandardsHandler;
        protected readonly IProcessQueueWorker          _processQueueWorker;
        protected readonly IActionWorker                _actionTasksHandler;
        protected readonly IValidationCallbacksContainer _validationCallbacksContainerHandler;

        public WINorm(ILogger loggerHandler ,  IRepositoryStoreManager repositoryManagerHandler , INormsStandardManager normsStandardsHandler, IProcessQueueWorker processQueueWorker, IActionWorker taskActionsHandler, IValidationCallbacksContainer validationCallbacksContainer)
        {
            this._loggerHandler                         = loggerHandler.InitiateAlertInstance;
            this._repositoryManagerHandler              = repositoryManagerHandler;
            this._normsStandardsHandler                 = normsStandardsHandler;
            this._processQueueWorker                    = processQueueWorker;
            this._actionTasksHandler                    = taskActionsHandler;
            this._validationCallbacksContainerHandler   = validationCallbacksContainer;
        }

        public TokenProvisionerModel Register(TokenProvisionerModel payload)
        {
            try
            {
               return (TokenProvisionerModel)_normsStandardsHandler.RegisterProcess(processEntityType: payload.ProcessEntityType, processSurveyKey: payload.ProcessSuveryKey, claimsIdentity: payload.ClaimsIdentity, interfaceKey: payload.InterfaceKey, norm: payload.Norm);
            }
            catch(TimeoutException e)
            {
                throw new TimeoutException("Time out error occured while waiting to complete your request. Please try again , or use asynchronous call to consume our services.");
            }
            catch (Exception e)
            {
                throw new FaultException<TokenProvisionerModel>( new TokenProvisionerModel { StatusCode = "412", ErrorMessage = "There was an error processing your request", ErrorStackTrace = e.StackTrace,ClaimsIdentity = payload.ClaimsIdentity, InterfaceKey = payload.InterfaceKey,  Norm = payload.Norm });
            }
        }


        public async Task<ProcessRequestModel> RequestAsync(ProcessRequestModel payload)
        {
            try
            {
                return (ProcessRequestModel) await _normsStandardsHandler.ValidateProcessTokenAsync(payload.RequestToken, (ProcessRequestModelProxy)payload, _processQueueWorker);
            } 
            catch (TimeoutException e)
            {
                throw new TimeoutException("Time out error occured while waiting to complete your request. Please try again , or use asynchronous call to consume our services.");
            }
            catch (Exception e)
            {
                throw new FaultException<TokenProvisionerModel>(new TokenProvisionerModel { StatusCode = "412", ErrorMessage = "There was an error processing your request", ErrorStackTrace = e.StackTrace, ClaimsIdentity = payload.ClaimsIdentityId, InterfaceKey = payload.InterfaceKey, Norm = payload.Norm });
            }
        }

        
        //public IAsyncResult BeginProcessRequest(WorkItemInstance payload, AsyncCallback callback, object state)
        //{
        //    return new CompletedAsyncResult<Norm>(_WIHandler.ConvertToNormProcess<Norm>(payload)); //Determines which process the token belongs to and returns a norm
        //}
        //public async Task<WorkItemInstance> EndProcessRequest(Norm payload, IAsyncResult result)
        //{
        //    return await _WIHandler.ProcessNormInstanceRequest(payload, _payloadTrafficer, _logger, _dataStoreManager, _actionManager);
        //}

    }
}
//WebOperationContext.Current.OutgoingResponse.StatusCode         = System.Net.HttpStatusCode.InternalServerError;
//WebOperationContext.Current.OutgoingResponse.StatusDescription  = e.StackTrace;