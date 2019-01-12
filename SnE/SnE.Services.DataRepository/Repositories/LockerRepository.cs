using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Reflection;

namespace DoE.Lsm.Data.Repositories.Lock
{
    using EF;
    using Logger;
    using Annotations.Exceptions;

    public class LockerRepository : RepositoryFactory<WILock> , ILockRepository
    {
        public LockerRepository(DbContext context, ILogger logger)  : base(context, logger) {}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entityType"></param>
        /// <param name="entityId"></param>
        [WatchException(For: typeof(InvalidDatabaseOperationException), code: 1055, exception: "There was an error locking your item.Please contact technical support for any assistance")]
        public void Lock(string entityType, string entityId, string token)
        {
            try
            {

            var entity = new WILock
            {
                 EntityType     = entityType,
                 EntityId       = entityId,
                 LockedBy       = token,
                 LockedFrom     = DateTime.Now,
                 ReleasedAt     = null,
                 ReleasedBy     = null 
            };

            Db.WILocks.Add( entity);

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
        [WatchException(For: typeof(InvalidDatabaseOperationException), code: 1055, exception: "There was an error unlocking your item.Please contact technical support for any assistance")]
        public void UnLock(string entityType, string entityId, string creatorToken, string releaserToken)
        {
            try
            {
                var entity = Db.WILocks
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

        protected PortalSnE Db { get { return this._DbContext as PortalSnE; } }

    }
}
