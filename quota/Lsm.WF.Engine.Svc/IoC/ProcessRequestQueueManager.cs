using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DoE.Lsm.WF.Configurations
{
    using Core;
    using Logger;
    using WI.Api;
    using Data.Repositories;
    using Service.WI.Proxies;
    using Component.Requisitions;

    public sealed class ProcessRequestQueueManager : IProcessQueueWorker
    {
        private Dictionary<string, NormProcess> processManager = new Dictionary<string, NormProcess>(); 

        public ProcessRequestQueueManager(ILogger logger, IRepositoryStoreManager dataStoreRepository,  IActionWorker actionManager)
        {
            processManager.Add("Lsm.Requisitions", new RequisitionProcessImp(logger, dataStoreRepository, actionManager));
        }

        public async Task<ProcessRequestModelProxy> Queue(ProcessRequestModelProxy payload, INormsStandardManager NIHandler)
        {
            return await processManager[payload.InterfaceKey].ExecuteStep(payload, NIHandler); //starts the process       
        }
    }
}