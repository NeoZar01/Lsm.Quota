using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnE.WF.Service.Validation.Validations
{
    using DoE.SnE.WF.Service.Validation.Api;

    public class PreliminaryValidation
    {

        public string outcome;

        public delegate string PreliminaryValidationCallback(string entityType, string entityId);

        public PreliminaryValidationCallback PreliminaryCheck;

        public void RunPreliminaryCheck(ValidationCallbacksContainer callback, string entityType, string entityId)
        {
            PreliminaryCheck = callback.PreliminaryCheckCallBack;
            outcome          = PreliminaryCheck(entityType, entityId);
        }
    }
}
