using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoE.SnE.WF.Service.Validation.Api
{
    public class ValidationCallbacksContainer : IValidationCallbacksContainer
    {
        public string PreliminaryCheckCallBack(string entityType , string entityId) {
            return "FAILED";
        }
    }
}
