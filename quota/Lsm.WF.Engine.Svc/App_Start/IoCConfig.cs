using Unity;

namespace DoE.Lsm.WF.Engine.Configurations
{
    using Api;
    using Logger;
    using Data.Repositories;
    using Context.Entities;

    public class IoCConfig
    {
        /// <summary>
        ///      Add dependant containers
        /// </summary>
        /// <param name="container"></param>
        public static void ConfigureContainer(IUnityContainer container)
        {
             container.RegisterType<ILogger, GenericLogger>();
             container.RegisterType<IRepositoryStoreManager, RepositoryStoreManager>();
             container.RegisterType<IProcessFlowManager, ProcessFlowManager>();
             container.RegisterType<IRole, Role>();
        }
    }
}