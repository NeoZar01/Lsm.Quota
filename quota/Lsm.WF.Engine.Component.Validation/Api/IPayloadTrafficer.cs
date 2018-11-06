using System.Threading.Tasks;

namespace DoE.Lsm.WF.WI.Api
{
    using Core;
    using Context.Norms;
    using Models;

    public interface IPayloadTrafficer
    {
        Task<WorkItemInstance> Queue(Norm payload , INormInstanceHandler NIHandler);
    }
}
