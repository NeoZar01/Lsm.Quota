using Microsoft.Practices.Unity;

namespace DoE.Lsm.Services.Caller.IoC
{
    using Logger;
    using Data.Repositories;
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
                .RegisterType<ILogger, BaseLogger>()
                .RegisterType<IRepositoryStoreManager, RepositoryStoreManager>()
                .RegisterType<IServicesFactory, Caller>();
        }

    }
}
