using System;

using Castle.Windsor;
using Castle.MicroKernel.Registration;
using Castle.Facilities.WcfIntegration;

namespace DoE.Lsm.WF.Engine.Svc
{
    using Api;
    using Logger;
    using Engine;
    using Data.Repositories;
    using Configurations;

    public class Global : System.Web.HttpApplication
    {
        private static IWindsorContainer container;

        protected void Application_Start(object sender, EventArgs e)
        {
            container = new WindsorContainer();
            container.AddFacility<WcfFacility>()
                  .Register(
                        Castle.MicroKernel.Registration.Component.For<IProcessFlowManager>().ImplementedBy<ProcessFlowManager>(),
                        Castle.MicroKernel.Registration.Component.For<ILogger>().ImplementedBy<BaseLogger>(),
                        Castle.MicroKernel.Registration.Component.For<IRepositoryStoreManager>().ImplementedBy<RepositoryStoreManager>(),
                        Castle.MicroKernel.Registration.Component.For<IWorkflowConfig>().ImplementedBy<WorkflowConfig>());
        }
    }
}