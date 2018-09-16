using System.Collections.Generic;
using System.Threading.Tasks;

namespace DoE.Lsm.WF.Engine.Context
{
    using Data.Repositories;
    using Component.Requisition;

    /// <summary> Auto-switchboard for re-routing requests  
    ///          <para>The constructor configures routes into a <c> Dictionary<WF.Tools.Route, WF.Utils.Items.Utils.RequestRoute> </c> allowing the Workflow engine to throw key in order to re-route requests </para>
    ///          <para> To add a new route onto your map. 
    ///              <para>
    ///                  Add your new route name to route constants <see cref="WF.Tools.Routes" />
    ///                  Build a class that inherits the class <code> WF.Utils.Items.Utils.RequestRoute </code>
    ///                  Add your new route
    ///                  <example>
    ///                              <param>Route Map Entry</param>
    ///                              <param>Destinated class</param>                
    ///                      <code>  _map.Add(Route.Requisition, new RequisitionMap(repositoryContext));   </code>
    ///                  </example> 
    ///              </para>
    ///          </para>
    ///
    ///  <see cref="WF.Tools.Request" />
    ///  <see cref="WF.Utils.Items.Utils.RequestRoute " />
    ///  <see cref="WF.Tools.Route" />
    /// </summary>
    public sealed class Map
    {                
        private Dictionary<Key, RouteFactory> _routeContext = new Dictionary<Key, RouteFactory>(); //Stores your routes

        public Map(IRepositoryStoreRegistry store)
        {
            _routeContext.Add(Key.Requisition, new RequisitionMap(store));  
        }

        ///<summary> 
        ///     Routes a request to its destinated component.   
        ///</summary>
        public async Task<ExecutionResult> Turn(PayloadContext payload)
        {
              return await _routeContext[payload.Route].TakeAsync(payload);            
        }
    }
}
