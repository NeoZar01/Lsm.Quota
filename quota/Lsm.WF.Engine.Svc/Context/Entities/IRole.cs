using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace DoE.Lsm.WF.Engine.Context.Entities
{
    public interface IRole
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="succesor"></param>
        void SetSuccessor(IRole succesor);

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="token"></param>
        /// <param name="payload"></param>
        /// <returns></returns>
        Task<ExecutionResult> ProcessRequest<T>(T token, ProcessWorkItem payload) where T : class;

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="token"></param>
        /// <param name="payload"></param>
        /// <returns></returns>
        Task<ExecutionResult> ProcessRequestAsync<T>(T token, ProcessWorkItem payload) where T : class;
    }
}