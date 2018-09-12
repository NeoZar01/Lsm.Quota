using System.Threading.Tasks;

namespace DoE.Lsm.WF.Engine.Context
{
    ///<summary> 
    ///    Re-routes Requests via the <c>HttpPayload </c> class
    ///</summary>
    public abstract class RouteFactory
    {
       
        protected JobInstance processOutcome;

        /// <summary>  
        ///      Takes the request to the designated module.
        /// </summary>
        public abstract Task<ExecutionResult> TakeAsync(PayloadContext payload);

    }
}