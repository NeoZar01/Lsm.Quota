using System;
using System.Threading.Tasks;

namespace DoE.Lsm.WF.Engine.Context.Entities
{

    using Data.Repositories;
    using Data.Repositories.EF;

    public abstract class Role
    {
        public volatile int                  response = -1;
        public Role                         _successor;
        public readonly IRepositoryStoreRegistry    _repositoryStore;

        public Role(IRepositoryStoreRegistry repositoryStore)
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
        public virtual async Task<ExecutionResult> ProcessRequestAsync<T>(T WFObject, PayloadContext payload) where T : class
        {
            var map = new Map(_repositoryStore);
            return  await map.Turn(payload);
        }

        /// <summary> Processes a dynamical call passing the class <c>Lsm.WF.Utils.Request</c> as a parameter.
        ///      <para> Using generics converts object passed to this method - allowing a dynamic control of all requests coming for different processing responses. </para>
        ///      <para> <see cref="Lsm.WF.Engine.RouteMapContext.Context" /> on how requests are dynamically routed using a stragety pattern. /> </para>  
        ///      <return> Determines whether process job was successfuly or not. <return>
        /// </summary>
        public virtual Task<ExecutionResult> ProcessRequest<T>(T WFObject, PayloadContext request) where T : class
        {
            var routeMapper = new Map(_repositoryStore);
            return routeMapper.Turn(request);
        }

        ///  <summary>    
        ///      Use station and rank to get profile data.
        ///  </summary>
        [Obsolete("I changed the model structure of this table <c>AspNetProfile</c> by breaking some columns into tables individually.", false)]
        public AspNetProfile GetAccountDetails( DoE.Lsm.WF.Engine.Context.Role role, short station)
        {
             return _repositoryStore.ProfileStore.GerUserProfileByRankAndStation((int)role , station);
        }

    }
}
