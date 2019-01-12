using System.Web.Mvc;

namespace DoE.Lsm.Web.Areas.ProcessManager.Controllers
{
    using Api;
    using Logger;
    using Data.Repositories;
    public class SystemHealthController : BaseAPIController
    {
        public SystemHealthController(ILogger logger, IRepositoryStoreManager repositoryStore) : base(logger, repositoryStore){}

        //public ActionResult Index()
        //{
        //    return this.View();
        //}
    }
}