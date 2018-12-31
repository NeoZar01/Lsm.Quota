using System;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Threading.Tasks;

namespace DoE.Lsm.WF.Service.Web.Contracts
{
    using Models;
    using WF.Web.Models;


    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract(Namespace ="")]
    public interface IWI
    {

        /// <summary>
        ///     Uses the ProcessEntityType | ClaimsToken to create a new Process 
        /// </summary>
        /// <param name="payload"></param>
        /// <returns></returns>
        [WebInvoke(Method = "POST",
                   BodyStyle = WebMessageBodyStyle.Bare,
                   RequestFormat = WebMessageFormat.Json,
                   ResponseFormat = WebMessageFormat.Json,
                   UriTemplate = "/Services/Rest/Tokens/Register/{payload}")]
        TokenProvisionerModel Register(TokenProvisionerModel payload);


        /// <summary>
        /// 
        /// </summary>
        /// <param name="payload"></param>
        /// <returns></returns>
        [WebInvoke(Method = "POST",
                   BodyStyle = WebMessageBodyStyle.Bare,
                   RequestFormat = WebMessageFormat.Json,
                   ResponseFormat = WebMessageFormat.Json,
                   UriTemplate = "/Services/Rest/Processes/Request/{payload}")]
        Task<ProcessRequestModel> RequestAsync(ProcessRequestModel payload);

    }
}