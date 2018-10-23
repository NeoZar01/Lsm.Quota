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
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public abstract ProcessStepsFactory Start(ProcessWorkItem payload, IRepositoryStoreManager dataStoreManager);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public abstract ProcessStepsFactory PreConfig(string instanceCaseId, IRepositoryStoreManager dataStoreManager, params object[] object_0001);

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
