using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoE.Lsm.WF.Engine.Component.Monitor.Api
{
    using DoE.Lsm.Data.Repositories;

    public class Lock : IDisposable
    {

        public IRepositoryStoreManager _dbStore;
        public string _entityType;
        public string _entityId;
        public string _creatorToken;
        /// <summary>
        ///   Allows to only throw a kill command 
        /// </summary>
        /// <param name="dbStore"></param>
        public Lock(IRepositoryStoreManager dbStore)
        { this._dbStore = dbStore; }

        public Lock(IRepositoryStoreManager dbStore, string entityType, string entityId, string userToken)
        {
            this._dbStore       = dbStore;
            this._entityType    = entityType;
            this._entityId      = entityId;
            this._creatorToken  = userToken;

            _dbStore.Locker.Lock(entityType, entityId, userToken);
        }

        public virtual void Kill(string entityType, string entityId, string creatorToken, string releaserToken)
        {
            _dbStore.Locker.UnLock(entityType, entityId, creatorToken, releaserToken);
        }

        /// <summary>
        ///  Allows the use of <c>using(){}</c> to lock and unlock an entity in one batch.
        /// </summary>
        public void Dispose()
        {
            Kill(_entityType, _entityId, _creatorToken,  _creatorToken);
        }
    }
}
 