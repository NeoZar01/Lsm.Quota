using System;
using System.Runtime.Serialization;

namespace DoE.Lsm.WF.Service.Web.Models
{
    using WI.Proxies;
    using WI.Proxies.Models;

    using static StringExtension.ConditionFlavor;

    [DataContract(Namespace = "")]
    public partial class ProcessRequestModel : ProcessRequestModelFactory
    {
        [DataMember]
        public override string RequestToken { get; set; }

        [DataMember]
        public override string InterfaceId { get; set; }

        [DataMember]
        public override string EntityType { get; set; }

        [DataMember]
        public override string ClaimsId { get; set; }

        [DataMember]
        public override string SurveyId { get; set; }

        [DataMember]
        public override string EntityId { get; set; }

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

        [DataMember]
        public override string ConsortiumGroupId { get; set; }

        [DataMember]
        public override string ProcessCD { get; set; }

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
                proxy.RequestToken      = model.SecurityToken.IsRequired(null, Null);
                proxy.ProcessInstanceId = model.ProcessInstanceId;
                proxy.InterfaceId       = model.InterfaceId.IsRequired(null, Null);
                proxy.EntityType        = model.EntityType.IsRequired(null, Null);
                proxy.EntityId          = model.EntityId.IsRequired(null, Null);
                proxy.ClaimsId          = model.PersonId.IsRequired(null, Null);
                proxy.SurveyId         = model.SurveyId.IsRequired(null, Null);
                proxy.ConsortiumGroupId = model.ConsortiumGroupId;
                return proxy;
            }
            catch
            {
                return null;
            }
        }

    }
}