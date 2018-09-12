using System;
using System.Threading.Tasks;

namespace DoE.Lsm.WF.Component.Requisitions.Factories
{

    using Data.Repositories;
    using Engine.Context;

    /// <summary>
    ///     Handles drafts and readonly requisitions
    /// </summary>

    public abstract class DiscardFactory : JobInstance
    {

        /// <summary>
        /// 
        /// </summary>
        protected readonly IRepositoryStore _repositoryStore;

        public DiscardFactory(Guid instanceId, IRepositoryStore repositoryStore) : base(repositoryStore.Requisitions.DbContext, instanceId)
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
        public abstract Task<JobInstance>   ParkAsync(string station, string state, ReadMode readType);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="payload"></param>
        /// <param name="readType"></param>
        /// <returns></returns>
        public abstract DiscardFactory      CreateFlowInstance(PayloadContext payload, ReadMode readType);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="payload"></param>
        /// <param name="readType"></param>
        /// <returns></returns>
        public abstract Task<JobInstance>   CreateFlowInstanceAsync(PayloadContext payload, ReadMode readType);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="payload"></param>
        /// <param name="readType"></param>
        /// <returns></returns>
        public abstract DiscardFactory      CreateStepInstance(PayloadContext payload, ReadMode readType);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="payload"></param>
        /// <param name="readType"></param>
        /// <returns></returns>
        public abstract Task<JobInstance>   CreateStepInstanceAsync(PayloadContext payload, ReadMode readType);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="payload"></param>
        /// <param name="TransactionRead"></param>
        /// <returns></returns>
        public abstract DiscardFactory Start(PayloadContext payload, ReadMode TransactionRead);

    }
}
