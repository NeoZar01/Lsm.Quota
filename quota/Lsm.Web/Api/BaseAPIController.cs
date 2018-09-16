using System.Web.Http;
using Microsoft.AspNet.Identity;

namespace DoE.Lsm.Web.Api
{
    using Logger;
    using Data.Repositories;

    /// <summary>
    /// 
    /// </summary>   
    [Authorize]
    public class BaseAPIController : ApiController
    {
        public readonly ILogger _logger;
        public readonly IRepositoryStoreRegistry _dataStore;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="repositoryStore"></param>
        public BaseAPIController(ILogger logger, IRepositoryStoreRegistry repositoryStore)
        {
                        this._logger = logger;
                        this._dataStore = repositoryStore;
        }

        /// <summary>
        /// 
        /// </summary>
        public virtual int EmisCode
        {
            get
            { return User.Identity.GetUserName().ToInt(); }
        }

    }
}
