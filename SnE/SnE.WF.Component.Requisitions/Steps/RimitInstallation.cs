using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoE.Lsm.WF.Component.Requisitions.Steps
{
    using Api;
    using WI.Api;
    using Logger;
    using Service.WI.Proxies;
    using Data.Repositories;
    using SnE.WF.Service.Validation.Api;

    public class RimitInstallation : RequisitionStepAction
    {
        protected readonly IRepositoryStoreManager _repositoryManager;
        protected readonly ILogger _logger;

        public override void ProcessRequestedTask(ValidationCallbacksContainer validationCallbackContainer, ProcessRequestModelProxy payload, IStandardNormsRepository norm, out string outcome)
        {
            throw new NotImplementedException();
        }

        public RimitInstallation(ILogger logger, IRepositoryStoreManager repositoryManager)
        {
            this._repositoryManager = repositoryManager;
            this._logger = logger;
        }
    }
}
