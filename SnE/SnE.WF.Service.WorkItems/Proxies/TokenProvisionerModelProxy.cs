using System;

namespace DoE.Lsm.WF.Service.WI.Proxies
{
    using Models;
    using static StringExtension.ValidationFlavor;

    public partial class TokenProvisionerModelProxy
    {

        public static explicit operator TokenProvisionerModelProxy(TokenProvisionerModelFactory model)
        {
            if (model == null) { throw new ArgumentNullException("model"); }

            try
            {
                TokenProvisionerModelProxy proxy = new TokenProvisionerModelProxy();
                proxy.ClaimsIdentity             = model.ClaimsIdentity.IsRequired(null, Null);
                proxy.InterfaceKey               = model.InterfaceKey.IsRequired(null, Null);
                proxy.ProcessEntityType          = model.ProcessEntityType.IsRequired(null, Null);
                proxy.ProcessInstanceId          = model.ProcessInstanceId;
                proxy.ProcessInstanceToken       = model.ProcessInstanceToken.IsRequired(null, Null);
                proxy.ProcessSuveryKey           = model.ProcessSuveryKey.IsRequired(null, Null);
                proxy.StatusCode                 = model.StatusCode.IsRequired(null, Null);
                return proxy;
            }
            catch
            {
                return null;
            }
        }
    }

    public partial class TokenProvisionerModelProxy
    {

        public string Norm { get; set; }

        public string ProcessInstanceToken { get; set; }

        public string ProcessInstanceId { get; set; }

        public string ProcessEntityType { get; set; }

        public string ProcessSuveryKey { get; set; }

        public string ClaimsIdentity { get; set; }

        public string InterfaceKey { get; set; }

        public string StatusCode { get; set; }


        public string param_001
        { get; set; }

        public string param_002
        { get; set; }

        public string param_003
        { get; set; }

        public string param_004
        { get; set; }

        public string param_005
        { get; set; }

        public string param_006
        { get; set; }

        public string param_007
        { get; set; }

        public string param_008
        { get; set; }

        public string param_009
        { get; set; }

        public string param_0010
        { get; set; }
    }



}
