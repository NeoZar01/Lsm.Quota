using System.Runtime.Serialization;
using System;

namespace DoE.Lsm.WF.Web.Models
{
    using Service.WI.Proxies;
    using Service.WI.Proxies.Models;
    using static StringExtension.ConditionFlavor;

    [DataContract(Namespace = "")]
    public partial class TokenProvisionerModel : TokenProvisionerModelFactory
    {
        [DataMember]
        public override string ErrorMessage { get; set; }

        [DataMember]
        public override string ErrorStackTrace { get; set; }

        [DataMember]
        public override string StatusCode { get; set; }
    }

    public partial class TokenProvisionerModel
    {
        [DataMember]
        public override string Norm { get; set; }

        [DataMember]
        public override string InterfaceKey { get; set; }

        [DataMember]
        public override string ProcessInstanceToken { get; set; }

        [DataMember]
        public override string ProcessInstanceId { get; set; }

        [DataMember]
        public override string ProcessEntityType { get; set; }

        [DataMember]
        public override string ProcessSuveryKey { get; set; }

        [DataMember]
        public override string ClaimsIdentity { get; set; }

    }

    public partial class TokenProvisionerModel
    {
        public static explicit operator TokenProvisionerModel(TokenProvisionerModelProxy model)
        {
            if (model == null) { throw new ArgumentNullException("proxy"); }

            try
            {
                TokenProvisionerModel proxy = new TokenProvisionerModel();
                proxy.ClaimsIdentity        = model.PersonId.IsRequired(null, Null);
                proxy.InterfaceKey          = model.interfaceCode.IsRequired(null, Null);
                proxy.ProcessEntityType     = model.EntityType.IsRequired(null, Null);
                proxy.ProcessInstanceId     = model.InstanceId;
                proxy.ProcessInstanceToken  = model.SecurityToken;
                proxy.ProcessSuveryKey      = model.SurveyId.IsRequired(null, Null);
                proxy.StatusCode            = model.StatusCode;             
                return proxy;
            }
            catch
            {
                return null;
            }
        }
    }
}