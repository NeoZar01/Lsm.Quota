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

        [TODO("Rename this method to ProcessStepInquest.")]
        public async Task<ProcessRequestModel> RequestAsync(ProcessRequestModel payload)
        {
            try
            {
                return (ProcessRequestModel) await _normsStandardsHandler.ProcessRequestStep(payload.RequestToken, (ProcessRequestModelProxy)payload, _processQueueWorker);
            } 
            catch (TimeoutException e)
            {
                throw new TimeoutException("Time out error occured while waiting to complete your request. Please try again , or use asynchronous call to consume our services.");
            }
            catch (Exception e)
            { 
                throw new FaultException<TokenProvisionerModel>(new TokenProvisionerModel { StatusCode = "412", ErrorMessage = "There was an error processing your request", ErrorStackTrace = e.StackTrace, ClaimsIdentity = payload.ClaimsId, InterfaceKey = payload.InterfaceId, Norm = payload.SurveyId });
            }
        }

        #region Constructor
        protected readonly ILogger _loggerHandler;
        protected readonly IRepositoryStoreManager _repositoryManagerHandler;
        protected readonly IStandardNormsRepository _normsStandardsHandler;
        protected readonly IRequestPoolWorker _processQueueWorker;
        protected readonly ITaskActionWorker _actionTasksHandler;
        protected readonly IValidationCallbacksContainer _validationCallbacksContainerHandler;

        public WINorm(ILogger loggerHandler, IRepositoryStoreManager repositoryManagerHandler, IStandardNormsRepository normsStandardsHandler, IRequestPoolWorker processQueueWorker, ITaskActionWorker taskActionsHandler, IValidationCallbacksContainer validationCallbacksContainer)
        {
            this._loggerHandler = loggerHandler.ConfigureAlert;
            this._repositoryManagerHandler = repositoryManagerHandler;
            this._normsStandardsHandler = normsStandardsHandler;
            this._processQueueWorker = processQueueWorker;
            this._actionTasksHandler = taskActionsHandler;
            this._validationCallbacksContainerHandler = validationCallbacksContainer;
        }
        #endregion

    }
}
