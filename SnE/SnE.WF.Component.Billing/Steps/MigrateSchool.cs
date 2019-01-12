using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoE.Lsm.WF.Component.Requisitions.Preliminary.Steps
{
    using WI.Api;
    using Logger;
    using WI.Context.Norms;
    using Requisitions.Api;
    using Data.Repositories;
    using Service.WI.Proxies;
    using SnE.WF.Service.Validation.Api;

    public class MigrateSchool : RequisitionStepAction
    {
        protected readonly IRepositoryStoreManager _repositoryManager;
        protected readonly ILogger _logger;

        /// <summary>
        ///     This calls a stored procedure that schedules the school to be migrated overnight.
        ///     This should return via a service call to the client notifying them about the success of their batch. 
        /// </summary>
        /// <param name="validationCallbackContainer"></param>
        /// <param name="payload"></param>
        /// <param name="payload.Data_002">EntityId</param>
        /// <param name="payload.Data_003">StagingTable</param>
        /// <param name="norm"></param>
        /// <param name="outcome"></param>
        public override void ProcessRequestedTask(ValidationCallbacksContainer validationCallbackContainer, ProcessRequestModelProxy payload, IStandardNormsRepository norm, out string outcome)
        {
            string custordian          = norm.Custordian;
            string extractId           = payload.param_001;
            string schema              = payload.param_002;
            string dimension           = payload.param_003;
            string key_001             = Guid.NewGuid().ToString();

            _repositoryManager.ExtractScheduler.ScheduleEntityMigration<School>(extractId, payload.SurveyId, payload.ConsortiumGroupId, payload.EntityType, payload.EntityId, custordian , schema, dimension, key_001, null,null, null, null, null, null, null, null, null, null, out outcome );
        }

        #region  Constructors 
        public MigrateSchool(ILogger logger, IRepositoryStoreManager repositoryManager)
        {
            this._repositoryManager = repositoryManager;
            this._logger            = logger;
        }
        #endregion
    }
}