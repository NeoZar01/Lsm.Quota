using System;

using Castle.Windsor;
using Castle.MicroKernel.Registration;
using Castle.Facilities.WcfIntegration;

namespace DoE.Lsm.WF.Services
{
    using Logger;
    using WI.Api;
    using WI.Config;
    using Service.Web;
    using Service.Web.Contracts;

    using Configurations;
    using Data.Repositories;
    using SnE.WF.Service.Validation.Api;

    public class Global : System.Web.HttpApplication
    {
        private static IWindsorContainer container;

        protected void Application_Start(object sender, EventArgs e)
        {
            container = new WindsorContainer();
            container.AddFacility<WcfFacility>()
                  .Register(
                        Castle.MicroKernel.Registration.Component.For<IWI>().ImplementedBy<WINorm>(),
                        Castle.MicroKernel.Registration.Component.For<ILogger>().ImplementedBy<BaseLogger>(),
                        Castle.MicroKernel.Registration.Component.For<IRepositoryStoreManager>().ImplementedBy<RepositoryStoreManager>(),
                        Castle.MicroKernel.Registration.Component.For<IValidationCallbacksContainer>().ImplementedBy<ValidationCallbacksContainer>(),
                        Castle.MicroKernel.Registration.Component.For<INormsStandardManager>().ImplementedBy<NormsStandardManager>(),
                        Castle.MicroKernel.Registration.Component.For<IProcessQueueWorker>().ImplementedBy<ProcessRequestQueueManager>());
        }
    }
}