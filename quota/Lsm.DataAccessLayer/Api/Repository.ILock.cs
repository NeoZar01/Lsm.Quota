using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoE.Lsm.Data.Repositories.Api
{
    using EF;

    public interface ILockRepository : IRepository<C_Lock>
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entityType"></param>
        /// <param name="entityId"></param>
        void Lock(string entityType, string entityId, string token);


        /// <summary>
        /// 
        /// </summary>
        /// <param name="entityType"></param>
        /// <param name="entityId"></param>
        void UnLock(string entityType, string entityId, string creatorToken, string releaserToken);
    }
}
