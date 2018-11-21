﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoE.Lsm.WF.Component.Requisitions.ProcessSteps
{
    using Api;
    using WI.Api;
    using Logger;
    using Service.WI.Proxies;
    using Data.Repositories;
    using SnE.WF.Service.Validation.Api;

    public class RimitInstallation : RequisitionStep
    {
        protected readonly IRepositoryStoreManager _repositoryManager;
        protected readonly ILogger _logger;

        public override void ExecuteTask(ValidationCallbacksContainer validationCallbackContainer, ProcessRequestModelProxy payload, INormsStandardManager norm, out string outcome)
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