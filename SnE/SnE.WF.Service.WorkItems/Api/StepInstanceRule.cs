using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoE.Lsm.WF.Engine.Service.WorkItem.Api
{
    public interface IStepInstanceRule
    {
        IStepInstanceRule EscationRules(int[] settings);
    }
}
