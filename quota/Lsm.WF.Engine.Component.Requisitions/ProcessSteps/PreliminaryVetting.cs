using System;

namespace DoE.Lsm.WF.Component.Requisitions.ProcessSteps
{
    using Api;
    using Data.Repositories;
    using global::SnE.WF.Service.Validation.Validations;
    using Logger;
    using Service.WI.Proxies;
    using SnE.WF.Service.Validation.Api;
    using WI.Api;

    public class PreliminaryVetting : RequisitionStep
    {
        protected readonly IRepositoryStoreManager _repositoryManager;
        protected readonly ILogger _logger;


        private PreliminaryValidation preliminaryVetting;

        public override void ExecuteTask(ValidationCallbacksContainer validationCallbackContainer, ProcessRequestModelProxy payload, INormsStandardManager norm, out string outcome)
        {
            if (string.IsNullOrEmpty(payload.param_001) || string.IsNullOrWhiteSpace(payload.param_001)) throw new ArgumentNullException("param_001");
            if (string.IsNullOrEmpty(payload.param_002) || string.IsNullOrWhiteSpace(payload.param_002)) throw new ArgumentNullException("param_002");

            preliminaryVetting = new PreliminaryValidation();
            preliminaryVetting.RunPreliminaryCheck(validationCallbackContainer, payload.param_001, payload.param_002);

            outcome = preliminaryVetting.outcome;
        }

        public PreliminaryVetting(ILogger logger, IRepositoryStoreManager repositoryManager)
        {
            this._repositoryManager = repositoryManager;
            this._logger = logger;
        }
    }
}
