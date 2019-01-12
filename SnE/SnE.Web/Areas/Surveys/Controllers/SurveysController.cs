using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DoE.Lsm.Web.Mvc.Areas.Surveys.Controllers
{
    using Api;
    using Data.Repositories;
    using Logger;

    public class SurveysController : BaseController
    {
        public SurveysController(ILogger logger, IRepositoryStoreManager repositoryStore) : base(logger, repositoryStore){}
    }
}