using DoE.Lsm.WF.Engine.Context.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoE.Lsm.WF.Engine.WI.Tools
{
    using Logger;
    using Context;
    using Data.Repositories;
    using Engine.Context;

    public abstract class ProcessStepsFactory
    {
        protected readonly IRepositoryStoreManager _dataStoreManager;
        protected readonly ILogger _logger;

        public ProcessStepsFactory(ILogger logger, IRepositoryStoreManager dataStoreManager) {
              this._dataStoreManager = dataStoreManager;
              this._logger = logger;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public abstract ProcessStepsFactory PreStart(ProcessWorkItem payload);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public abstract ProcessStepsFactory Start();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public abstract ProcessStepsFactory Config(string entityType, string instanceCaseId, string command);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public abstract ProcessStepsFactory ExecuteAction();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public abstract ProcessStepsFactory Process(ProcessWorkItem payload);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public abstract Task<ProcessStepsFactory> End();
    }
}
