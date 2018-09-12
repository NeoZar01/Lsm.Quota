using System.Threading.Tasks;
using System.Data.Entity;
using System;

namespace DoE.Lsm.WF.Engine.Context
{

    /// <summary>
    ///    Every tasks should inherit this class.This will enabled a dynamic carryover of your EF DbContexts.And in turn enables dirty read transactions.
    /// </summary>
    public abstract class JobInstance
   {

        protected DbContext _dataContext; //For Transactions

        /// <summary>
        ///     Passess parent ProcessInstanceId
        /// </summary>
        public string ProcessInstanceId = string.Empty;

        /// <summary>
        ///    Passes parent stepinstance
        /// </summary>
        public string StepInstanceId    = string.Empty;


        /// <summary>
        ///     Outcome of a instance
        /// </summary>
        public string outcome           = string.Empty;


        /// <summary>
        /// 
        /// </summary>
        public string state             = string.Empty;

        /// <summary>
        ///   Instantiates the JobInstance child with this backing field.
        /// </summary>
        protected readonly Guid _instanceId;

        /// <summary>
        ///   Job
        /// </summary>
        public int job = -1;


        public JobInstance(DbContext dataContext, Guid instanceId)
        {
            this._dataContext = dataContext;
            this._instanceId  = instanceId;
        }

   }
    
}
