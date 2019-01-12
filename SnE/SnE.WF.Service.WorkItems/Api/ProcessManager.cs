using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoE.Lsm.WF.WI.Tools
{
    public class ProcessManager
    {
        public static ProcessInstance From(ProcessInstance jobInstance, string outcome)
        {
            jobInstance.outcome = outcome;
            return jobInstance;
        }
    }
}
