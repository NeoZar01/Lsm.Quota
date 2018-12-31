using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoE.Lsm.WF.Component.Requisitions.Api;
using DoE.Lsm.WF.Service.WI.Proxies;
using DoE.Lsm.WF.WI.Api;
using DoE.SnE.WF.Service.Validation.Api;

namespace SnE.WF.Component.Requisitions.Preliminary.Steps
{
    public class InstallSurvey : RequisitionStepAction
    {

        public override void ProcessRequestedTask(ValidationCallbacksContainer validationCallbackContainer, ProcessRequestModelProxy payload, IStandardNormsRepository norm, out string outcome)
        {
            throw new NotImplementedException();
        }
    }
}
