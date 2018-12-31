using System;

namespace DoE.Lsm.WF.Service.WI.Proxies
{
    using Models;
    using static StringExtension.ConditionFlavor;

    public class ProcessRequestModelProxy 
    {

        public string SecurityToken { get; set; }
        public string ProcessCD     { get; set; }
        public string InterfaceId   { get; set; }
        public string SurveyId      { get; set; }
        public string PersonId      { get; set; }
        public string EntityId      { get; set; }
        public string EntityType    { get; set; }

        public string ProcessInstanceId { get; set; }
        public string ConsortiumGroupId { get; set; }

        public string param_001    { get; set; }
        public  string param_002    { get; set; }
        public  string param_003    { get; set; }
        public  string param_004    { get; set; }
        public  string param_005    { get; set; }
        public  string param_006    { get; set; }
        public  string param_007    { get; set; }
        public  string param_008    { get; set; }
        public  string param_009    { get; set; }
        public  string param_0010   { get; set; }


        public static explicit operator ProcessRequestModelProxy(ProcessRequestModelFactory model)
        {
            if (model == null) { throw new ArgumentNullException("model"); }

            try
            {
                ProcessRequestModelProxy proxy = new ProcessRequestModelProxy();
                proxy.SecurityToken = model.RequestToken.IsRequired(null, Null);
                proxy.ProcessInstanceId = model.ProcessInstanceId;
                proxy.InterfaceId = model.InterfaceId.IsRequired(null, Null);
                proxy.EntityType = model.EntityType.IsRequired(null, Null);
                proxy.EntityId = model.EntityId.IsRequired(null, Null);
                proxy.PersonId = model.ClaimsId.IsRequired(null, Null);
                proxy.SurveyId = model.SurveyId.IsRequired(null, Null);
                proxy.ConsortiumGroupId = model.ConsortiumGroupId.IsRequired(null, Null);
                proxy.ProcessCD = model.ProcessInstanceId;
                return proxy;
            }
            catch
            {
                return null;
            }
       }
    }
}