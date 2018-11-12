using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DoE.Lsm.WF.Configurations
{
    using Core;
    using Logger;
    using WI.Api;
    using Data.Repositories;
    using Component.Requisition;
    using WI.Context.Norms;
    using WI.Models;

    public sealed class PayloadTrafficer : IPayloadTrafficer
    {

        private Dictionary<string, NormProcess> processManager = new Dictionary<string, NormProcess>(); 

        public PayloadTrafficer(ILogger logger, IRepositoryStoreManager dataStoreRepository,  IActionTaskFactory actionManager)
        {
            processManager.Add("Lsm.Requisitions", new RequisitionsProcess(logger, dataStoreRepository, actionManager));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="payload"></param>
        /// <returns></returns>
        public async Task<WorkItemInstance> Queue(Norm payload, INormInstanceHandler NIHandler)
        {
            return await processManager[payload.Process].Process(payload, NIHandler); //starts the process
        }

    }
}