using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoE.Lsm.WF.Engine.Context
{
    public class Process
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="jobInstance"></param>
        /// <param name="outcome"></param>
        /// <returns></returns>
        public static ProcessInstance From(ProcessInstance jobInstance, string outcome)
        {
            jobInstance.outcome = outcome;
            return jobInstance;
        }
    }
}
