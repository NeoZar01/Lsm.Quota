using System;
using System.Runtime.Serialization;

namespace DoE.Lsm.WF.Service.Web.Models
{
    using WI.Proxies;
    using WI.Proxies.Models;

    using static StringExtension.ValidationFlavor;

    [DataContract(Namespace = "")]
    public partial class ProcessRequestModel : ProcessRequestModelFactory
    {
        [DataMember]
        public override string RequestToken { get; set; }

        [DataMember]
        public override string InterfaceKey { get; set; }

        [DataMember]
        public override string InterfaceEntityType { get; set; }

        [DataMember]
        public override string ClaimsIdentityId { get; set; }

        [DataMember]
        public override string Norm { get; set; }

        [DataMember]
        public override string InterfaceEntityId { get; set; }

        [DataMember]
        public override string param_001 { get; set; }

        [DataMember]
        public override string param_002 { get; set; }

        [DataMember]
        public override string param_003 { get; set; }

        [DataMember]
        public override string param_004 { get; set; }

        [DataMember]
        public override string param_005 { get; set; }

        [DataMember]
        public override string param_006 { get; set; }

        [DataMember]
        public override string param_007 { get; set; }

        [DataMember]
        public override string param_008 { get; set; }

        [DataMember]
        public override string param_009 { get; set; }

        [DataMember]
        public override string param_0010 { get; set; }

    }

        public partial class ProcessRequestModel
        {
            public override string ProcessInstanceId  {  get; set; }
        }


       public partial class ProcessRequestModel
       {
        public static explicit operator ProcessRequestModel(ProcessRequestModelProxy model)
        {
            if (model == null) { throw new ArgumentNullException("model"); }

            try
            {
                ProcessRequestModel proxy = new ProcessRequestModel();
                proxy.RequestToken          = model.RequestToken.IsRequired(null, Null);
                proxy.ProcessInstanceId     = model.ProcessInstanceId;
                proxy.InterfaceKey          = model.InterfaceKey.IsRequired(null, Null);
                proxy.InterfaceEntityType   = model.InterfaceEntityType.IsRequired(null, Null);
                proxy.InterfaceEntityId     = model.InterfaceEntityId.IsRequired(null, Null);
                proxy.ClaimsIdentityId      = model.ClaimsIdentityId.IsRequired(null, Null);
                proxy.Norm                  = model.Norm.IsRequired(null, Null);

                return proxy;
            }
            catch
            {
                return null;
            }
        }

    }
}