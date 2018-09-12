namespace DoE.Lsm.Services.Api
{
    using Logger;
    using ShoppingCardNamespace = ShoppingCard.Api;


    /// <summary>
    /// 
    /// </summary>
    public interface IServicesFactory
    {

        /// <summary>
        /// 
        /// </summary>
        ShoppingCardNamespace::IShoppingCard ShoppingCard { get; set; }

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
