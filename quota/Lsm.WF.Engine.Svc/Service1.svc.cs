using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace DoE.Lsm.WF.Engine
{
    using Api;
    using Data.Repositories;

    public class WFEngineService : IWFEngineService
    {
        public readonly IRepositoryStore _DbRepository;
        public WFEngineService(IRepositoryStore DbRepository)
        {this._DbRepository = DbRepository;}
    }
}
