using System;
using System.Threading.Tasks;

namespace DoE.Lsm.WF.Component.Requisitions.Factories
{

    using Data.Repositories;
    using Engine.Context;
    using Engine.WI.Tools;

    /// <summary>
    ///     Handles drafts and readonly requisitions
    /// </summary>

    public abstract class DiscardFactory : ProcessInstance
    {

        /// <summary>
        /// 
        /// </summary>
        protected readonly IRepositoryStoreManager _repositoryStore;

        public DiscardFactory(Guid instanceId, IRepositoryStoreManager repositoryStore) : base(repositoryStore.Requisitions.DbContext, instanceId)
        {this._repositoryStore = repositoryStore;}


        /// <summary>
        /// 
        /// </summary>
        /// <param name="station"></param>
        /// <param name="state"></param>
        /// <param name="readType"></param>
        /// <returns></returns>
        public abstract DiscardFactory      Park(string station, string state, ReadMode readType);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="station"></param>
        /// <param name="state"></param>
        /// <param name="readType"></param>
        /// <returns></returns>
        public abstract Task<ProcessInstance>   ParkAsync(string station, string state, ReadMode readType);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="payload"></param>
        /// <param name="readType"></param>
        /// <returns></returns>
        public abstract DiscardFactory      CreateFlowInstance(ProcessWorkItem payload, ReadMode readType);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="payload"></param>
        /// <param name="readType"></param>
        /// <returns></returns>
        public abstract Task<ProcessInstance>   CreateFlowInstanceAsync(ProcessWorkItem payload, ReadMode readType);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="payload"></param>
        /// <param name="readType"></param>
        /// <returns></returns>
        public abstract DiscardFactory      CreateStepInstance(ProcessWorkItem payload, ReadMode readType);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="payload"></param>
        /// <param name="readType"></param>
        /// <returns></returns>
        public abstract Task<ProcessInstance>   CreateStepInstanceAsync(ProcessWorkItem payload, ReadMode readType);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="payload"></param>
        /// <param name="TransactionRead"></param>
        /// <returns></returns>
        public abstract DiscardFactory Start(ProcessWorkItem payload, ReadMode TransactionRead);

    }
}
