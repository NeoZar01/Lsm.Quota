using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoE.Lsm.WF.Service.WI.Proxies.Models
{
    public abstract class ProcessRequestModelFactory
    {

        public abstract  string RequestToken { get; set; }

        public abstract string ProcessInstanceId { get; set; }

        public abstract string InterfaceKey { get; set; }

        public abstract string InterfaceEntityType  { get; set; }

        public abstract string InterfaceEntityId{ get; set; }

        public abstract string ClaimsIdentityId  { get; set; }

        public abstract string Norm  { get; set; }



        public abstract string param_001 { get; set; }

        public abstract string param_002 { get; set; }

        public abstract string param_003 { get; set; }

        public abstract string param_004 { get; set; }

        public abstract string param_005 { get; set; }

        public abstract string param_006 { get; set; }

        public abstract string param_007 { get; set; }

        public abstract string param_008 { get; set; }

        public abstract string param_009 { get; set; }

        public abstract string param_0010 { get; set; }

    }
}
