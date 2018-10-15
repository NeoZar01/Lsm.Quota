using System;
using System.Collections.Generic;

using System.Web.Mvc;
using System.Threading.Tasks;

namespace DoE.Lsm.Web.Controllers
{
    using Models;
    using Api;
    using Logger;
    using Data.Repositories;
    using DoE.Web.Mvc.Api;

    [Authorize(Roles ="")]
    public class HomeController : BaseController
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly Dictionary<string, DashboardFactoryViewModel> _dashboardModels = new Dictionary<string, DashboardFactoryViewModel>();

        public HomeController(ILogger logger, IRepositoryStoreManager dataStore) : base(logger, dataStore)
        {
            _dashboardModels.Add(EntityType.CircuitManager, new CircuitDashboardViewModel());
            _dashboardModels.Add(EntityType.Administrator,  new AdministratorDashboardViewModel());
        }

        /// <summary>
        /// 
        /// </summary>
        [HttpGet]
        public async Task<ActionResult> Index()
        {
            if (string.IsNullOrEmpty(User.Identity.GetRole()) && string.IsNullOrEmpty(User.Identity.GetToken()))
            return View();

            return View(await _dashboardModels[User.Identity.GetRole()].Return(User.Identity.GetToken() , _repositoriesDataStore));
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpGet]
        [ChildActionOnly]
        public ActionResult BuildDashboard(DashboardFactoryViewModel model)
        {
            return PartialView(model.Page.IsNullReplaceWith("_mainpagedashboard_error"), model);
        }
    }
}