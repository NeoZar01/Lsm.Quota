using System;

namespace DoE.Lsm.WF.Service.WI.Proxies
{
    using Models;
    using static StringExtension.ValidationFlavor;

    public class ProcessRequestModelProxy 
    {

        public static explicit operator ProcessRequestModelProxy(ProcessRequestModelFactory model)
        {
            if (model == null) { throw new ArgumentNullException("model"); }

            try
            {
                ProcessRequestModelProxy proxy = new ProcessRequestModelProxy();
                proxy.RequestToken          = model.RequestToken.IsRequired(null, Null);
                proxy.ProcessInstanceId     = model.ProcessInstanceId;
                proxy.InterfaceKey          = model.InterfaceKey.IsRequired(null, Null);
                proxy.InterfaceEntityType   = model.InterfaceEntityType.IsRequired(null, Null);
                proxy.InterfaceEntityId     = model.InterfaceEntityId.IsRequired(null, Null);
                proxy.ClaimsIdentityId      = model.ClaimsIdentityId.IsRequired(null, Null);
                proxy.Norm                  = model.Norm.IsRequired(null , Null);
                return proxy;
            }
            catch
            {
                return null;
            }
        }


        public  string RequestToken { get; set; }

        public  string ProcessInstanceId { get; set; }

        public  string InterfaceKey { get; set; }

        public  string InterfaceEntityId { get; set; }

        public  string InterfaceEntityType { get; set; }

        public  string ClaimsIdentityId { get; set; }

        public  string Norm { get; set; }


        public string param_001 { get; set; }

        public  string param_002 { get; set; }

        public  string param_003 { get; set; }

        public  string param_004 { get; set; }

        public  string param_005 { get; set; }

        public  string param_006 { get; set; }

        public  string param_007 { get; set; }

        public  string param_008 { get; set; }

        public  string param_009 { get; set; }

        public  string param_0010 { get; set; }
    }
}
