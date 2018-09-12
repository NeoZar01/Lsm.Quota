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
        public readonly IRepositoryStore _dataStore;

        public BaseController(ILogger logger, IRepositoryStore repositoryStore)
        {
                            this._logger           = logger;
                            this._dataStore = repositoryStore;
        }


        public virtual int EmisCode
        {
            get
            { return User.Identity.GetUserName().ToInt(); }
        }






        //public virtual Guid GERID
        //{
        //    get
        //    {
        //        return db_connection.Person.GlobalId = new Guid(User.Identity.GetUserName());
        //    }
        //}

        //public virtual string PortalEmisId
        //{
        //    get
        //    {
        //        return GERID.ToString();
        //    }
        //}

    }
}