using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoE.Lsm.WF.Service.WI.Proxies.Models
{
    public abstract class TokenProvisionerModelFactory
    {

         public abstract string ErrorMessage { get; set; }

        public abstract string ErrorStackTrace { get; set; }

        public abstract string StatusCode { get; set; }

        public abstract string Norm { get; set; }

        public abstract string InterfaceKey { get; set; }

        public abstract string ProcessInstanceToken { get; set; }

        public abstract string ProcessInstanceId { get; set; }

        public abstract string ProcessEntityType { get; set; }

        public abstract string ProcessSuveryKey { get; set; }

        public abstract string ClaimsIdentity { get; set; }
    }
}
