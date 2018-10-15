using System;
using System.Threading.Tasks;

namespace DoE.Lsm.WF.Engine.Context.Entities
{

    using Data.Repositories;
    using Data.Repositories.EF;

    public abstract class Role
    {
        public volatile int response = 0;
        public Role        _successor;
        public readonly IRepositoryStoreManager    _repositoryStore;

        public Role(IRepositoryStoreManager repositoryStore)
        {   this._repositoryStore = repositoryStore;  }


        /// <summary>
        ///      Dynamically sets successor for a role.
        /// </summary>
        public virtual void SetSuccessor(Role succesor)
        {   this._successor = succesor;   }


        /// <summary> Processes a dynamical call asynchronously  passing the class <c>Lsm.WF.Utils.Request</c> as a parameter.
        ///      <para> Using generics converts object passed to this method - allowing a dynamic control of all requests coming for different processing responses. </para>
        ///      <para> <see cref="Lsm.WF.Engine.RouteMapContext.Context" /> on how requests are dynamically routed using a stragety pattern. /> </para>  
        ///      <return> Determines whether process job was successfuly or not. <return>
        /// </summary>
        public virtual async Task<ExecutionResult> ProcessRequestAsync<T>(T WFObject, ProcessCase payload) where T : class
        {
            var map = new Filter(_repositoryStore);
            return  await map.Process(payload);
        }

        /// <summary> Processes a dynamical call passing the class <c>Lsm.WF.Utils.Request</c> as a parameter.
        ///      <para> Using generics converts object passed to this method - allowing a dynamic control of all requests coming for different processing responses. </para>
        ///      <para> <see cref="Lsm.WF.Engine.RouteMapContext.Context" /> on how requests are dynamically routed using a stragety pattern. /> </para>  
        ///      <return> Determines whether process job was successfuly or not. <return>
        /// </summary>
        public virtual Task<ExecutionResult> ProcessRequest<T>(T token, ProcessCase request) where T : class
        {
            var routeMapper = new Filter(_repositoryStore);
            return routeMapper.Process(request);
        }
    }
}
