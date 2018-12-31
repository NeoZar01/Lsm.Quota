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
    using Component.Requisitions.Preliminary;

    public sealed class RequestPoolWorker : IRequestPoolWorker
    {
        private Dictionary<string, NormProcess> processManager = new Dictionary<string, NormProcess>(); 

        public RequestPoolWorker(ILogger logger, IRepositoryStoreManager dataStoreRepository,  ITaskActionWorker actionWorker)
        {
            processManager.Add("Lsm.Requisitions.Preliminary", new RequisitionProcessImp (logger, dataStoreRepository, actionWorker));
            processManager.Add("Lsm.Requisitions", new RequisitionsPreliminaryProcessImp(logger, dataStoreRepository, actionWorker));
        }

        public async Task<ProcessRequestModelProxy> QueueRequestsPool(ProcessRequestModelProxy payload, IStandardNormsRepository NIHandler)
        {
            return await processManager[payload.InterfaceId].Run(payload, NIHandler); //starts the process       
        }
    }
}