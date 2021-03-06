﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoE.Lsm.WF.Component.Requisitions.Api
{
    using WI.Api;
    using Service.WI.Proxies;
    using SnE.WF.Service.Validation.Api;

    public abstract class RequisitionStepAction
    {
        public abstract void ProcessRequestedTask(ValidationCallbacksContainer validationCallbackContainer, ProcessRequestModelProxy payload, IStandardNormsRepository norm, out string outcome);
    }


}
