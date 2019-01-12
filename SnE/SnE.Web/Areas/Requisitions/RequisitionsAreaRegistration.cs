using System.Web.Mvc;

namespace DoE.Lsm.Web.Requisitions
{
    public class RequisitionsAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {get{return "Requisitions";}}

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Requisitions_default",
                "Requisitions/{controller}/{action}/{id}",
                new { controller ="Home" , action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}