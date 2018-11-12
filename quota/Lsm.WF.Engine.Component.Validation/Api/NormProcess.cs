using System.Threading.Tasks;

namespace DoE.Lsm.WF.WI.Api
{
    using Context.Norms;
    using Models;

    public interface NormProcess
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="payload"></param>
        /// <param name="NIHandler"></param>
        /// <returns></returns>
       Task<WorkItemInstance> Process(Norm payload, INormInstanceHandler NIHandler);
    }
}