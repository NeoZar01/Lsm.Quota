namespace DoE.Lsm.Services.Api
{
    using Logger;
    using Data.Repositories;


    /// <summary>
    /// 
    /// </summary>
    public interface IServicesFactory
    {
        /// <summary>
        /// 
        /// </summary>
       RepositoryStoreManager RepositoryStoreService { get; set; }

        /// <summary>
        /// 
        /// </summary>
        ILogger Logger { get; set; }

    }
}
