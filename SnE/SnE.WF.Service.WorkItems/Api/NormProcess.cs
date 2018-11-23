using System.Threading.Tasks;

namespace DoE.Lsm.WF.WI.Api
{
    using Context.Norms;
    using Service.WI.Proxies;

    public interface NormProcess
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="processModel"></param>
        /// <param name="NIHandler"></param>
        /// <returns></returns>
       Task<ProcessRequestModelProxy> ExecuteStep(ProcessRequestModelProxy processModel, INormsStandardManager NIHandler);
    }
}