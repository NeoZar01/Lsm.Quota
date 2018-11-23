using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Practices.Unity;
using System.Collections.Generic;

namespace DoE.Lsm.Web.Api
{
    /// <summary>
    /// 
    /// </summary>
    public class DependancyResolver : IDependencyResolver
    {

        private readonly IUnityContainer _container;

        public DependancyResolver(IUnityContainer container)
        {
            this._container = container;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="serviceType"></param>
        /// <returns></returns>
        public object GetService(Type serviceType)
        {
            if (!this._container.IsRegistered(serviceType))
            {
                return null;
            }
            return this._container.Resolve(serviceType);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="serviceType"></param>
        /// <returns></returns>
        public IEnumerable<object> GetServices(Type serviceType)
        {
            if (!this._container.IsRegistered(serviceType))
            {
                return new List<object>();
            }
            return this._container.ResolveAll(serviceType);
        }

    }
}