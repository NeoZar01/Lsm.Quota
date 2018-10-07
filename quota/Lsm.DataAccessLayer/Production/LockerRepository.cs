using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Reflection;

namespace DoE.Lsm.Data.Repositories.Lock
{
    using Api;
    using EF;
    using Logger;
    using Annotations.Exceptions;

    public class LockerRepository : RepositoryFactory<C_Lock> , ILockRepository
    {
        public LockerRepository(DbContext context, ILogger logger)  : base(context, logger) {}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entityType"></param>
        /// <param name="entityId"></param>
        [Watch(For: typeof(InvalidDatabaseOperationException), code: 1055, exception: "There was an error locking your item.Please contact technical support for any assistance")]
        public void Lock(string entityType, string entityId, string token)
        {
            try
            {

            var entity = new C_Lock {
                 EntityType     = entityType,
                 EntityId       = entityId,
                 LockedBy       = token,
                 LockedFrom     = DateTime.Now,
                 ReleasedAt     = null,
                 ReleasedBy     = null 
            };

            Db.C_Lock.Add( entity);

            Db.SaveChanges();

            }catch(Exception e)
            {
                throw new InvalidDatabaseOperationException(e.StackTrace, MethodBase.GetCurrentMethod().DeclaringType.ToString());
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entityType"></param>
        /// <param name="entityId"></param>
        [Watch(For: typeof(InvalidDatabaseOperationException), code: 1055, exception: "There was an error unlocking your item.Please contact technical support for any assistance")]
        public void UnLock(string entityType, string entityId, string creatorToken, string releaserToken)
        {
            try
            {
                var entity = Db.C_Lock
                 .Where( c => c.EntityType.Equals(entityType))
                 .Where( c => c.EntityId.Equals(entityId))
                 .Where( c => c.LockedBy.Equals(creatorToken))
                 .SingleOrDefault();

            entity.ReleasedBy = releaserToken;
            entity.ReleasedAt = DateTime.Now;

            Db.SaveChanges();

            }
            catch (Exception e)
            {
                throw new InvalidDatabaseOperationException(e.StackTrace, MethodBase.GetCurrentMethod().DeclaringType.ToString());
            }

        }

        protected PortalLsm Db { get { return this._DbContext as PortalLsm; } }

    }
}
