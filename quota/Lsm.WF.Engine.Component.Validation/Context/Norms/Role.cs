using System;
using System.Threading.Tasks;

namespace DoE.Lsm.WF.WI.Context.Norms
{

    using WF.WI.Api;
    using Logger;
    using Context;
    using Data.Repositories;
    using Engine.Context;

    public class Role : Norm
    {
        public volatile int response = 0;
        public INormInstanceHandler _successor;

        protected readonly IRepositoryStoreManager    _repositoryStore;
        protected readonly ILogger _logger;

        public Role(ILogger logger, IRepositoryStoreManager repositoryStore)
        {
            this._repositoryStore = repositoryStore;
            this._logger = logger;
        }

        public void SetSuccessor(INormInstanceHandler succesor)
        {
            this._successor = succesor;
        }

        public virtual void ProcessRequestItem() {}
    }
}