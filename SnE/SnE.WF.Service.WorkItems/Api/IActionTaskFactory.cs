using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoE.Lsm.WF.WI.Api
{
    using Data.Repositories;

    public interface ITaskActionWorker
    {

        /// <summary>
        /// 
        /// </summary>
        ProcessStepsFactory Invoke { get; }

    }
}