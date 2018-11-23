using System.Web.Mvc;

namespace DoE.Web.Mvc.Areas.Surveys
{
    public class SurveysAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Surveys";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Surveys_default",
                "Surveys/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}