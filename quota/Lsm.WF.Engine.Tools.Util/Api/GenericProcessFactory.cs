using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoE.Lsm.WF.Engine.Context
{
    using Api;

    public abstract class GenericProcessFactory : StepFactory
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>        
        public override StepFactory SetupStartStep(IGlobalConfigurationOption onStartup, object[] dependancyInjector)
        {           
            return this;
        }

        public override StepFactory PreConfig()
        {
            return this;
        }

        public override StepFactory Instantiate()
        {
            return this;
        }

        public override StepFactory Run()
        {
            return this;
        }

        public override Task<StepFactory> End()
        {
            return null;
        }
    }
}
