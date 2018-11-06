using System;

namespace DoE.Lsm.WF.WI.Config
{
    using System.Threading.Tasks;
    using Api;
    using Data.Repositories;
    using Core;
    using Logger;
    using Context.Norms;
    using Models;

    ///<summary>
    /// This can cause overheads when is loaded on every request.It should be loaded during start-up.(Currently its loaded by the Dependancy Injection container).
    ///<remark>This increases start-up time.</remark>
    ///</summary>
    public class NormInstanceHandler : INormInstanceHandler
    {

        public NormInstanceHandler(ILogger logger, IRepositoryStoreManager repositoryManager)
        {

                CircuitManager = new CircuitHandler(logger, repositoryManager);
                SubjectAnalyst = new SubjectAnalystHandler(logger, repositoryManager);
                School         = new SchoolHandler(logger, repositoryManager);

                SetSuccessor<SchoolHandler, SubjectAnalystHandler>(School, SubjectAnalyst);
                SetSuccessor<SubjectAnalystHandler, CircuitHandler>(SubjectAnalyst, CircuitManager);     
        }


        public CircuitHandler        CircuitManager { get; set; }
        public SchoolHandler         School         { get; set; }
        public SubjectAnalystHandler SubjectAnalyst { get; set; }

        public void SetSuccessor<T, T1>(Role predecessor, Role successor)  {   SetSuccessor<T, T1>(predecessor, successor); }

        public Norm ConvertToNormProcess<T>(WorkItemInstance payload) where T : class
        {return null;}

        public async Task<WorkItemInstance> ProcessNormInstanceRequest(Norm payload, IPayloadTrafficer payloadTrafficer, ILogger logger, IRepositoryStoreManager repositoryManager, IActionTaskFactory actionManager)
        {
          return await payloadTrafficer.Queue(payload, null);
        }
    }
}