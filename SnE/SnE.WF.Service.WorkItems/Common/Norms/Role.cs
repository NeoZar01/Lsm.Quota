using System;
using System.Threading.Tasks;

namespace DoE.Lsm.WF.WI.Context.Norms
{
    using Logger;
    using Data.Repositories;

    public class Role
    {
        public int response     = 0;
        public Role _successor;

        public void SetSuccessor(Role succesor)
        {
            this._successor = succesor;
        }

        public virtual void ProcessRequest() {}


        #region Constructor
        protected readonly ILogger _logger;
        protected readonly IRepositoryStoreManager _repositoryStore;

        public Role(ILogger logger, IRepositoryStoreManager repositoryStore)
        {
            this._repositoryStore = repositoryStore;
            this._logger = logger;
        }
        #endregion
    }
}