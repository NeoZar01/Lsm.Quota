using Microsoft.AspNet.Identity;
using System.Web.Mvc;

namespace DoE.Lsm.Web.Api
{

    using Logger;
    using Data.Repositories;

    [Authorize]
    public class BaseController : Controller
    {

        public readonly ILogger _logger;
        public readonly IRepositoryStoreManager _repositoriesDataStore;

        public BaseController(ILogger logger, IRepositoryStoreManager repositoryStore)
        {
                            this._logger           = logger;
                            this._repositoriesDataStore = repositoryStore;
        }

        public virtual int EmisCode
        {
            get
            { return User.Identity.GetUserName().ToInt(); }
        }

    }
}