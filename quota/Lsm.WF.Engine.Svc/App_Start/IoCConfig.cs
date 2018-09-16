using Unity;

namespace DoE.Lsm.WF.Engine.Configurations
{
    using Api;
    using Data.Repositories;

    public class IoCConfig
    {
        /// <summary>
        ///      Add dependant containers
        /// </summary>
        /// <param name="container"></param>
        public static void ConfigureContainer(IUnityContainer container)
        {
             container.RegisterType<IRepositoryStoreRegistry, RepositoryStore>();
             container.RegisterType<IWFEngineService, WFEngineService>();
        }
    }
}