using Microsoft.Practices.Unity;

namespace DoE.Lsm.Services.Caller.IoC
{
    using Logger;
    using Data.Repositories;
    using ShoppingCard.Api;
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
                .RegisterType<ILogger, AppLogger>()
                .RegisterType<IRepositoryStoreRegistry, RepositoryStore>()
                .RegisterType<IShoppingCard, ShoppingCard>()
                .RegisterType<IServicesFactory, Caller>();
        }

    }
}
