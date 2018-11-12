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

        protected readonly IRepositoryStoreManager _repositoryManager;

        public NormInstanceHandler(ILogger logger, IRepositoryStoreManager repositoryManager)
        {
                this._repositoryManager = repositoryManager;

                CircuitManager = new CircuitHandler(logger, repositoryManager);
                SubjectAnalyst = new SubjectAnalystHandler(logger, repositoryManager);
                School         = new SchoolHandler(logger, repositoryManager);

                SetSuccessor<SchoolHandler, SubjectAnalystHandler>(School, SubjectAnalyst);
                SetSuccessor<SubjectAnalystHandler, CircuitHandler>(SubjectAnalyst, CircuitManager);     
        }


        public CircuitHandler        CircuitManager { get; set; }
        public SchoolHandler         School         { get; set; }
        public SubjectAnalystHandler SubjectAnalyst { get; set; }

        public void SetSuccessor<T, T1>(Role predecessor, Role successor)
        {
                predecessor.SetSuccessor(successor);
        }

        /// <summary>
        ///   Uses conversion operators to convert the WorkItemInstance into a norm object.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="payload"></param>
        /// <returns></returns>
        public Norm ConvertToNormProcess<T>(WorkItemInstance payload) where T : class
        {
            string wiToken = string.Empty;

            _repositoryManager.WI.ResolveProcessInstance(payload.WIToken , out wiToken);
             payload.WIToken = wiToken;

            return (Norm)payload;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="payload"></param>
        /// <param name="payloadTrafficer"></param>
        /// <param name="logger"></param>
        /// <param name="repositoryManager"></param>
        /// <param name="actionManager"></param>
        /// <returns></returns>
        public async Task<WorkItemInstance> ProcessNormInstanceRequest(Norm payload, IPayloadTrafficer payloadTrafficer, ILogger logger, IRepositoryStoreManager repositoryManager, IActionTaskFactory actionManager)
        {
          return await payloadTrafficer.Queue(payload, this);
        }


        //public Role ResolveRoleToken(string token)
        //{
        //    if (string.IsNullOrEmpty(token)) throw new ArgumentNullException(nameof(token));

        //    Role instance = null;
        //    try
        //    {
        //        Type type = Type.GetType(token);
        //        instance = (Role)Activator.CreateInstance(type);
        //        var outcome = rmi.InvokeMember(context.RequestType.Equals("Async") ? "ProcessRequestAsync" : "ProcessRequest", InvokeMethod, null, instance, new object[] { });
        //        return instance;
        //    }
        //    catch (Exception e)
        //    {
        //        string excep = e.StackTrace;
        //    }

        //    return instance;
        //}
    }
}