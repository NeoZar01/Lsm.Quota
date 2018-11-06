using System;
using System.Threading.Tasks;

namespace DoE.Lsm.WF.Engine.Context.Entities
{

    using Data.Repositories;
    using Data.Repositories.EF;
    using Engine.Context;
    using Logger;
    using WI.Context.Entities;

    public abstract class Role : IRole
    {
        public volatile int response = 0;
        public IRole        _successor;

        protected readonly IRepositoryStoreManager    _repositoryStore;
        protected readonly ILogger _logger;
        public Role(ILogger logger, IRepositoryStoreManager repositoryStore)
        {   this._repositoryStore = repositoryStore;
            this._logger = logger;

        }


        /// <summary>
        ///      Dynamically sets successor for a role.
        /// </summary>
        public virtual void SetSuccessor(IRole succesor)
        {   this._successor = succesor;   }


        /// <summary> Processes a dynamical call asynchronously  passing the class <c>Lsm.WF.Utils.Request</c> as a parameter.
        ///      <para> Using generics converts object passed to this method - allowing a dynamic control of all requests coming for different processing responses. </para>
        ///      <para> <see cref="Lsm.WF.Engine.RouteMapContext.Context" /> on how requests are dynamically routed using a stragety pattern. /> </para>  
        ///      <return> Determines whether process job was successfuly or not. <return>
        /// </summary>
        public virtual async Task<ExecutionResult> ProcessRequestAsync<T>(T WFObject, ProcessWorkItem payload) where T : class
        {
            var map = new Filter(_logger, _repositoryStore);
            return  await map.Process(payload);
        }

        /// <summary> Processes a dynamical call passing the class <c>Lsm.WF.Utils.Request</c> as a parameter.
        ///      <para> Using generics converts object passed to this method - allowing a dynamic control of all requests coming for different processing responses. </para>
        ///      <para> <see cref="Lsm.WF.Engine.RouteMapContext.Context" /> on how requests are dynamically routed using a stragety pattern. /> </para>  
        ///      <return> Determines whether process job was successfuly or not. <return>
        /// </summary>
        public virtual Task<ExecutionResult> ProcessRequest<T>(T token, ProcessWorkItem request) where T : class
        {
            var routeMapper = new Filter(_logger, _repositoryStore);
            return routeMapper.Process(request);
        }
    }
}
