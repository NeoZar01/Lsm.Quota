using System.Threading.Tasks;

namespace DoE.Lsm.WF.Engine.Context
{
    ///<summary> 
    ///    Re-routes Requests via the <c>HttpPayload </c> class
    ///</summary>
    public interface RouteFactory
    {       
        /// <summary>  
        ///      Takes the request to the designated module.
        /// </summary>
        Task<ExecutionResult> Initiate(ProcessCase payload);
    }
}