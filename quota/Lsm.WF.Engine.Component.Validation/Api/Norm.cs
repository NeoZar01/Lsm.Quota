using System;
using System.Web.Mvc;

namespace DoE.Lsm.WF.WI.Context.Norms
{
    using Lsm;
    using Models;

    using static StringExtension.Flavor;

    public class Norm
    {

        /// <summary>
        ///  Converts WorkItem to Norm
        /// </summary>
        /// <param name="wi"></param>
        public static explicit operator Norm([Bind(Include ="IdentityToken , ProcessInstanceId")] WorkItemInstance wi)
        {

            if (wi == null) { throw new ArgumentNullException(nameof(wi)); }

            try
            {
                Norm norm       = new Norm();
                norm.Token              = wi.WIToken.CheckPropertyMerge(Null);
                norm.Process            = wi.ProcessInstanceId.CheckPropertyMerge(Null);
                norm.ProcessEntityType  = wi.InstanceEntityType.CheckPropertyMerge(Null);
                norm.ClaimsToken        = wi.IdentityToken.CheckPropertyMerge(Null);
                norm.ProcessEntityId    = wi.ProcessInstanceId.CheckPropertyMerge(Null);
                norm.param_001          = wi.param_001;
                norm.param_002          = wi.param_002;
                norm.param_003          = wi.param_003;
                norm.param_004          = wi.param_004;
                norm.param_005          = wi.param_005;
                norm.param_006          = wi.param_006;
                norm.param_007          = wi.param_007;
                norm.param_008          = wi.param_008;
                norm.param_009          = wi.param_009;
                norm.param_0010         = wi.param_0010;
                return norm;
            }catch
            {
                return null; 
            }
        }

        public string Token
        { get; set; }

        public Role Role { get; set; }

        public string Process
        { get; set; }

        public string ProcessEntityType
        { get; set; }

        public string ProcessEntityId
        { get; set; }

        public string ClaimsToken
        { get; set; }

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
