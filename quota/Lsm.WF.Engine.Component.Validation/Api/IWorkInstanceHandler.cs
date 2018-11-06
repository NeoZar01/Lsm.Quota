
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DoE.Lsm.WF.WI.Api
{
    using Core;
    using Context.Norms;
    using System.Threading.Tasks;
    using Data.Repositories;
    using Logger;
    using Models;

    public interface INormInstanceHandler
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="succesor"></param>
        void SetSuccessor<T, T1>(Role predecessor, Role successor);

        /// <summary>
        ///     Validates token thrown via the payload and returns a norm
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="token"></param>
        /// <param name="payload"></param>
        /// <returns></returns>
        Norm ConvertToNormProcess<T>(WorkItemInstance payload) where T : class;

        /// <summary>
        ///     
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="token"></param>
        /// <param name="payload"></param>
        /// <returns></returns>
        Task<WorkItemInstance> ProcessNormInstanceRequest(Norm payload , IPayloadTrafficer payloadTrafficer,  ILogger logger , IRepositoryStoreManager repositoryManager, IActionTaskFactory actionManager);

        /// <summary>
        /// 
        /// </summary>
        CircuitHandler CircuitManager { get; set; }

        /// <summary>
        /// 
        /// </summary>
        SchoolHandler School { get; set; }

        /// <summary>
        /// 
        /// </summary>
        SubjectAnalystHandler SubjectAnalyst { get; set; }
    }
}