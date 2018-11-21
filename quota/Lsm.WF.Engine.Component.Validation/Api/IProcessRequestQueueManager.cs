using System.Threading.Tasks;

namespace DoE.Lsm.WF.WI.Api
{
    using Context.Norms;
    using Service.WI.Proxies;

    public interface IProcessQueueWorker
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="payload"></param>
        /// <param name="NIHandler"></param>
        /// <returns></returns>
        Task<ProcessRequestModelProxy> Queue(ProcessRequestModelProxy payload , INormsStandardManager NIHandler);
    }
}
