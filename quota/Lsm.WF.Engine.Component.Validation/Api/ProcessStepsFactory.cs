using DoE.Lsm.WF.Engine.Context.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoE.Lsm.WF.WI.Api
{
    using Core;
    using Logger;
    using Data.Repositories;
    using Context.Norms;
    using Models;

    public abstract class ProcessStepsFactory
    {

        public IActionTaskFactory action;

        protected readonly ILogger _logger;
        protected readonly IRepositoryStoreManager _repositoryManager;

        public ProcessStepsFactory(ILogger logger, IRepositoryStoreManager dataStoreManager) {
                                 _repositoryManager  = dataStoreManager;
                                 _logger            = logger.InitiateWarningInstace ;
        }

        /// <summary>
        ///  Configures the step
        /// </summary>
        /// <returns></returns>
        public abstract ProcessStepsFactory Config(string entityType, string instanceCaseId, string command);

        /// <summary>
        ///     PreStarts the step
        /// </summary>
        /// <returns></returns>
        public abstract ProcessStepsFactory Start(Norm payload);

        /// <summary>
        ///   Starts the start
        /// </summary>
        /// <returns></returns>
        public abstract ProcessStepsFactory PreAction();

        /// <summary>
        ///     Execute the initial worker class for the particular step.
        /// </summary>
        /// <returns></returns>
        public abstract ProcessStepsFactory Action(INormInstanceHandler niHandler);

        //
        /// <summary>
        ///     Configures next Step
        /// </summary>
        /// <returns></returns>
        public abstract Task<WorkItemInstance> End();
    }
}