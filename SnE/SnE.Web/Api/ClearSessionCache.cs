using System;
using System.Web;
using System.Web.Mvc;

namespace DoE.Lsm.Web.Api.Filters
{

    /// <summary>
    ///      Assists in clearning cache for the current session.
    ///      <para>To avoid users from visisting pages with current depositored session data after log-out.</para>
    ///      <para>This will also need to be used for clearing cache when administators kills current running sessions.</para>
    /// </summary>
    public class ClearSessionCache : ActionFilterAttribute, IActionFilter
    {
        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            filterContext.HttpContext.Response.Cache.SetExpires(DateTime.UtcNow.AddDays(-1));
            filterContext.HttpContext.Response.Cache.SetValidUntilExpires(false);
            filterContext.HttpContext.Response.Cache.SetRevalidation(HttpCacheRevalidation.AllCaches);
            filterContext.HttpContext.Response.Cache.SetCacheability(HttpCacheability.NoCache);
            filterContext.HttpContext.Response.Cache.SetNoStore();

            base.OnResultExecuted(filterContext);
        }

    }
}