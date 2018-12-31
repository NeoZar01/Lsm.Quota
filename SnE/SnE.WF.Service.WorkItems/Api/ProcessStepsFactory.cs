using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoE.Lsm.WF.WI.Api
{
    using Logger;
    using Data.Repositories;
    using Service.WI.Proxies;

    public abstract class ProcessStepsFactory
    {

        public ITaskActionWorker action;

        /// <summary>
        ///     This method does the following
        ///     > Get the current step which the item is residing....
        ///     > Prepares the preceeding step - <c>initialise preceedingStepId</c> with the thrown Id and returns the ProcessStepFactory        
        /// </summary>
        /// <param name="model"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        public abstract ProcessStepsFactory Config(ProcessRequestModelProxy model, string command);

        public abstract ProcessStepsFactory Start                   { get;}

        /// <summary>
        ///   Starts the start
        /// </summary>
        /// <returns></returns>
        public abstract ProcessStepsFactory PreAction();

        /// <summary>
        ///     Execute the initial worker class for the particular step.
        /// </summary>
        /// <returns></returns>
        public abstract ProcessStepsFactory BeginAction(IStandardNormsRepository niHandler);

        /// <summary>
        ///     Configures next Step
        /// </summary>
        /// <returns></returns>
        public abstract ProcessStepsFactory PostAction();

        public abstract Task<ProcessRequestModelProxy> Stop         { get; }


        #region  Constructor
        public ProcessStepsFactory(ILogger logger, IRepositoryStoreManager dataStoreManager)
        {
            _repositoryManager  = dataStoreManager;
            _logger             = logger.ConfigureWarning;
        }

        protected readonly ILogger _logger;
        protected readonly IRepositoryStoreManager _repositoryManager;
        #endregion

    }
}