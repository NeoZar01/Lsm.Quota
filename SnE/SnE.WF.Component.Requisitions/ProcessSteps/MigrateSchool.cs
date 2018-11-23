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
    using Data.Repositories;
    using Service.WI.Proxies;
    using SnE.WF.Service.Validation.Api;

    public class MigrateSchool : RequisitionStep
    {
        protected readonly IRepositoryStoreManager _repositoryManager;
        protected readonly ILogger _logger;
        /// <summary>
        ///     This calls a stored procedure that schedules the school to be migrated overnight.
        ///     This should return via a service call to the client notifying them about the success of their batch. 
        /// </summary>
        /// <param name="norm"></param>
        public override void ProcessRequestedTask(ValidationCallbacksContainer validationCallbackContainer, ProcessRequestModelProxy payload, INormsStandardManager norm, out string outcome)
        {
            outcome = "Failed";
        }

        public MigrateSchool(ILogger logger, IRepositoryStoreManager repositoryManager)
        {
            this._repositoryManager = repositoryManager;
            this._logger            = logger;
        }
    }
}