namespace DoE.Lsm.Data.Repositories.Lock
{
    public interface ILockRepository
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entityType"></param>
        /// <param name="entityId"></param>
        /// <param name="token"></param>
        void Lock(string entityType, string entityId, string token);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entityType"></param>
        /// <param name="entityId"></param>
        /// <param name="creatorToken"></param>
        /// <param name="releaserToken"></param>
        void UnLock(string entityType, string entityId, string creatorToken, string releaserToken);

    }
}