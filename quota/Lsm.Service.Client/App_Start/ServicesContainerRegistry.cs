using Microsoft.Practices.Unity;

namespace DoE.Lsm.Services.Caller.IoC
{
    using Logger;
    using Data.Repositories;
    using ShoppingCardNs = ShoppingCard.Api;
    using Api;

    public static class ServicesContainerRegistry<T>
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="container"></param>
        public static void Install(IUnityContainer container)
        {
            container
                .RegisterType<ILogger, ErrorLogger>()
                .RegisterType<IRepositoryStoreRegistry, RepositoryStore>()
                .RegisterType<ShoppingCardNs::IShoppingCard, ShoppingCardNs::ShoppingCard>()
                .RegisterType<IServicesFactory, Caller>();
        }

    }
}
