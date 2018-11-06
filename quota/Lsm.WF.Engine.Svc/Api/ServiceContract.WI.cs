using System;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Threading.Tasks;

namespace DoE.Lsm.WF.Api
{
    using Core;
    using WI.Api;
    using WI.Context.Norms;
    using WI.Models;

    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract(Namespace ="")]
    public interface IWI
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="payload"></param>
        /// <param name="callback"></param>
        /// <param name="state"></param>
        /// <returns></returns>
        [OperationContract(AsyncPattern =true)]
        [WebInvoke(Method         = "POST",
                   BodyStyle      = WebMessageBodyStyle.Bare,
                   RequestFormat  = WebMessageFormat.Json,
                   ResponseFormat = WebMessageFormat.Json,
                   UriTemplate    = "LDoE/Services/SNE/Process/{payload}")]
        IAsyncResult BeginProcessRequest(WorkItemInstance payload, AsyncCallback callback, object state);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="payload"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        Task<WorkItemInstance> EndProcessRequest(Norm payload, IAsyncResult result);
    }
}
