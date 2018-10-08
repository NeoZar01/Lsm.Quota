using System.Web.Mvc;

namespace DoE.Lsm.Web.Requisitions.Controllers
{
    using Api;
    using Data.Repositories;
    using Logger;
    using Models;

    [Authorize]
    [RouteArea("Test")]
    //[RoutePrefix("SchoolCapture")]
    //[Route("{action=index}")]   //setup default route template
    public class CaptureController : BaseController
    {

        public CaptureController(ILogger logger, IRepositoryStoreRegistry repositoryStore) : base(logger, repositoryStore) {}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">Requisition Id</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Index(string id)
        {
            var model = new CaptureRequisitionsViewModel
            {
              //  Calendar = _repositoriesDataStore.StandardsAndNorms.BookYear
            };

            return View(model);
        }

    }
}