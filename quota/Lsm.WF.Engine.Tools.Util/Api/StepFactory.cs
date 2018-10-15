using DoE.Lsm.WF.Engine.Context.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoE.Lsm.WF.Engine.Context
{
    public abstract class StepFactory
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public abstract StepFactory SetupStartStep(IGlobalConfigurationOption onStartup, object[] dependancyInjector);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public abstract StepFactory PreConfig();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public abstract StepFactory Instantiate();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public abstract StepFactory Run();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public abstract Task<StepFactory> End();
    }
}
