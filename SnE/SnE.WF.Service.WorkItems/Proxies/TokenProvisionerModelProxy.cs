using System;

namespace DoE.Lsm.WF.Service.WI.Proxies
{
    using Models;
    using static StringExtension.ConditionFlavor;

    public partial class TokenProvisionerModelProxy
    {

        public string Norm              { get; set; }
        public string SecurityToken     { get; set; }
        public string InstanceId        { get; set; }
        public string EntityType        { get; set; }
        public string SurveyId          { get; set; }
        public string PersonId          { get; set; }
        public string interfaceCode     { get; set; }
        public string StatusCode        { get; set; }

        public string param_001         { get; set; }
        public string param_002         { get; set; }
        public string param_003         { get; set; }
        public string param_004         { get; set; }
        public string param_005         { get; set; }
        public string param_006         { get; set; }
        public string param_007         { get; set; }
        public string param_008         { get; set; }
        public string param_009         { get; set; }
        public string param_0010        { get; set; }
    }

    public partial class TokenProvisionerModelProxy
    {

        public static explicit operator TokenProvisionerModelProxy(TokenProvisionerModelFactory model)
        {
            if (model == null) { throw new ArgumentNullException("model"); }

            try
            {
                TokenProvisionerModelProxy proxy = new TokenProvisionerModelProxy();
                proxy.PersonId      = model.ClaimsIdentity.IsRequired(null, Null);
                proxy.interfaceCode = model.InterfaceKey.IsRequired(null, Null);
                proxy.EntityType    = model.ProcessEntityType.IsRequired(null, Null);
                proxy.InstanceId    = model.ProcessInstanceId;
                proxy.SecurityToken = model.ProcessInstanceToken.IsRequired(null, Null);
                proxy.SurveyId      = model.ProcessSuveryKey.IsRequired(null, Null);
                proxy.StatusCode    = model.StatusCode.IsRequired(null, Null);
                return proxy;
            }
            catch
            {
                return null;
            }
        }
    }


}
