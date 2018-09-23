using System;
using System.Threading.Tasks;
using System.Linq;
using System.Data.Entity;

namespace DoE.Lsm.Data.Repositories.Workflow.Engine
{
    using EF;
    using Logger;
    using Annotations.Exceptions;
    using WF.Engine.Context;
    using System.Reflection;

    //<summary>
    //     This repository will handle all the operations associated with managing the workflow engine.         
    //     <see cref="WF.Tools.ExecutionResult"> On Execution Results</see>
    //</summary>
    public partial class ProcessManagerRepository : RepositoryFactory<WFProcessInstance>, IProcessManager
    {
        //constructor
        public ProcessManagerRepository(DbContext context, ILogger logger) : base(context, logger) {}
        
        ///<summary>
        ///     Gets the <c>PortalLsm</c> data context as a data source 
        /// <value>  This property will recieve <c>DataContext</c> as as value and convert it to its derived class PortalLsm  </value>
        ///</summary>
        public PortalLsm WorkFlowStore { get { return this._DbContext as PortalLsm; } }

        ///<summary>
        ///    Creates a new Workflow Instance
        /// <param name="entityType"> Type of Entity</param>
        /// <param name="entityId"> Id of entity</param>
        /// <param name="createdby"> creator</param>
        /// <param name="state">Current state of the item in the workflow chain</param>
        /// <exception cref="DoE.DataServices.Exceptions.InvalidDatabaseOperationException.cs"></exception>
        ///</summary>
        [Watch( For: typeof(InvalidDatabaseOperationException) , code : 1055, exception: "There was an error creating a workflow instance.Please contact technical support for this issue.")]
        public string CreateFlowInstance<T>(string flowId, string entityId, string createdby, string completionDateVariable, string completionDateSubVariable, string state, string outcome) where T : class
        {
            
            if (string.IsNullOrEmpty(flowId)    || string.IsNullOrWhiteSpace(flowId))    throw new ArgumentNullException("flowId"); //avoid data loss by checking for mandatory parameters
            if (string.IsNullOrEmpty(entityId)  || string.IsNullOrWhiteSpace(entityId))  throw new ArgumentNullException("entityId"); //avoid data loss by checking for mandatory parameters
            if (string.IsNullOrEmpty(createdby) || string.IsNullOrWhiteSpace(createdby)) throw new ArgumentNullException("createdby"); //avoid data loss by checking for mandatory parameters
            if (string.IsNullOrEmpty(state)     || string.IsNullOrWhiteSpace(state))     throw new ArgumentNullException("state"); //avoid data loss by checking for mandatory parameters

            var instanceId      =    Guid.NewGuid();  //generates a new instanceId

            try
            {
                var entity = new WFProcessInstance
                {                     
                    InstanceId                          = instanceId,
                    FlowId                              = flowId,
                    EntityId                            = entityId,
                    CreatedDate                         = DateTime.Now,
                    LastModifiedDate                    = DateTime.Now,
                    CreatedBy                           = createdby,
                    LastEditedBy                        = createdby,
                    State                               = state,
                    CompletionDate                      = null,
                    ExceptedCompletionDateVariable      = completionDateVariable,
                    ExceptedCompletionDateSubVariable   = completionDateSubVariable,
                    Outcome                             = outcome

                };

                var job = (ExecutionResult) WorkFlowStore.SaveChanges();

                return job == ExecutionResult.Success ? instanceId.ToString() : null;           //returns null if ExecutionResult is a failed execution                         
            }
            catch(Exception e)
            {
                //log this error as a high priority thread and throw is back to the caller.
                throw new InvalidDatabaseOperationException(e.StackTrace , MethodBase.GetCurrentMethod().DeclaringType.ToString());
            }
        }

        ///<summary>
        ///    Creates a new Workflow Instance asynchronously
        /// <param name="entityType"> Type of Entity</param>
        /// <param name="entityId"> Id of entity</param>
        /// <param name="createdby"> creator</param>
        /// <param name="state">Current state of the item in the workflow chain</param>
        /// <exception cref="DoE.DataServices.Exceptions.InvalidDatabaseOperationException.cs"></exception>
        ///</summary>       
        [Watch(For: typeof(InvalidDatabaseOperationException) , code: 1055, exception: "There was an error creating a workflow instance.Please contact technical support for this issue.")]
        public async Task<string> CreateFlowInstanceAsync<T>(string flowId, string entityId, string createdby, string completionDateVariable, string completionDateSubVariable, string state, string outcome) where T : class
        {

            if (entityId == null || flowId == null) throw new ArgumentNullException("entityType");  //avoid data loss by checking for mandatory parameters

            var instanceId = Guid.NewGuid();

            try
            {
                var entity = new WFProcessInstance
                {
                    //RowGUID         = instanceId,
                    //FlowId          = flowId,
                    //EntityId        = entityId,
                    //ArrivalDate     = DateTime.Now,
                    //CreatedBy       = createdby,
                    //OnTakeState     = state,
                };

                var job    = (ExecutionResult) await WorkFlowStore.SaveChangesAsync();
                return job == ExecutionResult.Success ? instanceId.ToString() : null;           //returns null if ExecutionResult is a failed execution                         
            }
            catch (Exception e)
            {
                //log this error as a high priority thread and throw is back to the caller.
                throw new InvalidDatabaseOperationException(string.Concat("Failed to create a workflow instance. {", e.InnerException, "}")); ;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="flowId"></param>
        /// <param name="entityType"></param>
        /// <param name="entityId"></param>
        /// <param name="sender"></param>
        /// <param name="recepient"></param>
        /// <param name="state"></param>
        /// <returns></returns>
        [Watch(For: typeof(InvalidDatabaseOperationException), code: 1055, exception:"There was an error creating a workflow step.Please contact your administrator about this issue.")]
        public string CreateStepInstance(string flowId, string entityType, string entityId, string sender, string recepient, string completionDateVariable, string completionDateSubVariable, string state, string outcome)
        {

            var instanceId = Guid.NewGuid();

            try
            {

            var entity = new WFProcessInstance
            {
                 //RowGUID        = instanceId,
                 //ArrivalDate    = DateTime.Now,
                 //EntityId       = entityId,
                 //EntityType     = entityType,
                 //FlowId         = flowId,
                 //Recepient      = recepient,
                 //Sender         = sender,
                 //State          = state,
                 //TakeOffDate    = DateTime.Now
            };

            var job = (ExecutionResult)WorkFlowStore.SaveChanges();

            return job == ExecutionResult.Success ? instanceId.ToString() : null;
            } 
            catch
            {
                throw new InvalidDatabaseOperationException("Failed to create a step instance item.");
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="flowId"></param>
        /// <param name="entityType"></param>
        /// <param name="entityId"></param>
        /// <param name="creator"></param>
        /// <param name="recepient"></param>
        /// <param name="state"></param>
        /// <returns></returns>
        [Watch(For: typeof(InvalidDatabaseOperationException), code: 1055, exception: "There was an error creating a workflow step.Please contact your administrator about this issue.")]
        public async Task<string> CreateStepInstanceAsync(string flowId, string entityType, string entityId, string creator, string recepient, string completionDateVariable, string completionDateSubVariable, string state, string outcome)
        {
            var instanceId = Guid.NewGuid();

            try
            {

                var entity = new WFProcessInstance
                {
                    //RowGUID         = instanceId,
                    //ArrivalDate     = DateTime.Now,
                    //EntityId        = entityId,
                    //EntityType      = entityType,
                    //FlowId          = flowId,
                    //Recepient       = recepient,
                    //Sender          = creator,
                    //State           = state,
                    //TakeOffDate     = DateTime.Now
                };

                var job =  (ExecutionResult) await WorkFlowStore.SaveChangesAsync();

                return job == ExecutionResult.Success ? instanceId.ToString() : null;
            }
            catch
            {
                throw;
            }
        }

    }
}
