namespace DoE.Lsm.Services.Api
{
    using Logger;
    using ShoppingCard.Api;


    /// <summary>
    /// 
    /// </summary>
    public interface IServicesFactory
    {

        /// <summary>
        /// 
        /// </summary>
        IShoppingCard ShoppingCard { get; set; }

        /// <summary>
        /// 
        /// </summary>
 //       RepositoryStore RepositoryStoreService { get; set; }

        /// <summary>
        /// 
        /// </summary>
        ILogger Logger { get; set; }

    }
}
