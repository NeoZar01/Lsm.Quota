using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Microsoft.AspNet.Identity;

namespace DoE.Lsm.Web.Api.Filters
{
    public class LogSessionToMonitor : ActionFilterAttribute
    {

        private string sessionId;
        
        public  void OnActionExecuting(ResultExecutedContext filterContext)
        {

            if (HttpContext.Current.Session["SessionID"] == null)
            {


                


                filterContext.HttpContext.Session.Add("SessionID", this.Log = filterContext.HttpContext.Request.RequestContext.RouteData.DataTokens["UserIdToken"].ToString());

//                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { area = ConfigurationManager.AppSettings["RedirectURI:Area"], controller = ConfigurationManager.AppSettings["RedirectURI:Controller"], action = ConfigurationManager.AppSettings["RedirectURI:Action"] }));
                return;
            }

            base.OnResultExecuted(filterContext);
        }

        public string Log
        {
            get
            {
                return sessionId;
            }

            set
            {
                sessionId = value;
            }
        }

    }
}