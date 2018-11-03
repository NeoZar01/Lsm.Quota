using DoE.Lsm.WF.Engine.Context.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoE.Lsm.WF.Engine.WI.Tools
{
    using Context;
    using Data.Repositories;

    public abstract class ProcessStepsFactory
    {
        protected readonly IRepositoryStoreManager _dataStoreManager;
        public ProcessStepsFactory(IRepositoryStoreManager dataStoreManager) {
              this._dataStoreManager = dataStoreManager;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public abstract ProcessStepsFactory Start(ProcessWorkItem payload);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public abstract ProcessStepsFactory Config(string instanceCaseId , params string[] commands);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public abstract ProcessStepsFactory Instantiate();

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
