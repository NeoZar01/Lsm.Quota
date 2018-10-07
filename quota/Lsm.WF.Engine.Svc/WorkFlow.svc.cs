using System;
using System.ServiceModel.Activation;

namespace DoE.Lsm.WF.Engine
{
    using Api;
    using Context;
    using Svc.Context;

    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class WorkFlow : IWorkFlow
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="payload"></param>
        /// <returns></returns>
        public string ProcessRequest(PayloadContext payload)
        {
            return ProcessInvoker.Call(payload).Status;
        }
    }
}
