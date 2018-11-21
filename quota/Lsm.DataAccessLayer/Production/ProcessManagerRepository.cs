using System;
using System.Threading.Tasks;
using System.Linq;
using System.Data.Entity;

using System.Data.Entity.Core.Objects.DataClasses;


namespace DoE.Lsm.Data.Repositories.Workflow.Engine
{
    using EF;
    using Logger;
    using Annotations.Exceptions;
    using System.Reflection;
    using WF.Core;

    using static WF.Core.ExecutionResult;

    public partial class ProcessManagerRepository : RepositoryFactory<WIProcessInstance>, IProcessManager
    {
        [WatchException(typeof(InvalidDatabaseOperationException) , 1055, "An error occured while registering a new process.Please contact technical support for this issue.")]
        public void CreateProcessInstance<T>(string entityType, string claimsIdentity, string surveyKey, string interfaceKey, string normVariable, out DateTime expiryDate, out string processInstanceId) where T : class
        {            

            var instanceId  =  Guid.NewGuid();   

            processInstanceId = null;
            expiryDate        = DateTime.Now;   //expires the process within the specific instance.

            ConfigureExpiryDate(normVariable, interfaceKey, surveyKey, out expiryDate);

            try
            {
                var entity = new WIProcessInstance
                {                     
                    ProcessInstanceId                   = instanceId,
                    ExpiryDate                          = expiryDate,
                    LastModifiedDate                    = DateTime.Now,
                    CommencementDate                    = DateTime.Now,
                    ClaimsIdentity                      = claimsIdentity,
                    InterfaceKey                        = interfaceKey,
                    SurveyKey                           = surveyKey                         
                };

                var job = (ExecutionResult) db.SaveChanges();

                if(job == Success)
                {
                    processInstanceId   =  instanceId.ToString();
                }
            }
            catch(Exception e)
            {
                throw new InvalidDatabaseOperationException(e.StackTrace , MethodBase.GetCurrentMethod().DeclaringType.ToString());
            }
        }



        [WatchException(typeof(InvalidDatabaseOperationException), 1055, "An error occured while registering your process token.Please contact technical support for this issue.")]
        public void UpdateProcessToken<T>(Guid processInstanceId, string token) where T : class
        {
            var processInstance = db.WIProcessInstances.Where(c => c.ProcessInstanceId.Equals(processInstanceId)).SingleOrDefault();

            if(processInstance != null )
            {
                processInstance.ProcessToken = token;

                try
                {
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    throw new InvalidDatabaseOperationException(e.StackTrace, MethodBase.GetCurrentMethod().DeclaringType.ToString());
                }
            }
            throw new InvalidDatabaseOperationException("Process Instance Not Found", MethodBase.GetCurrentMethod().DeclaringType.ToString());
        }



        [WatchException(typeof(InvalidDatabaseOperationException), 1055, "An error occured while registering your process token.Please contact technical support for this issue.")]
        public void CreateInstanceSnapShot<T>(T payload, string currentStepInstanceId, string preceedingStepId, string preceedingStepInstanceId, string UserToken, string InstanceCaseId, string instanceEntityType, params string[] parameters) where T : class
        {
            throw new NotImplementedException();
        }



        [WatchException(typeof(InvalidDatabaseOperationException), 1055, "An error occured while registering your process token.Please contact technical support for this issue.")]
        public void InstallRules(string entityType, int[] settings)
        {
            throw new NotImplementedException();
        }



        [WatchException(typeof(InvalidDatabaseOperationException), 1055, "An error occured while registering your process token.Please contact technical support for this issue.")]
        public string ResolveProcessInstance(string processInstanceInputHash, out string processInstanceOutputHash)
        {
            throw new NotImplementedException();
        }


        [WatchException(typeof(InvalidDatabaseOperationException), 1055, "An error occured while registering your process token.Please contact technical support for this issue.")]
        public string CheckProcessToken(string requestToken)
        {
            throw new NotImplementedException();
        }


        [WatchException(typeof(InvalidDatabaseOperationException), 1055, "An error occured while registering your process token.Please contact technical support for this issue.")]
        public void SetupProcessStep(string instanceCaseId, out string precedingStepId, out string precedingStepInstanceId)
        {
            throw new NotImplementedException();
        }

    }



    #region Helpers 
    public partial class ProcessManagerRepository : RepositoryFactory<WIProcessInstance>, IProcessManager
    {

        [DbFunction("Portal.NormsStandardsModel.Store", "FN_InterfaceVariables")]
        public static string InterfaceVariables(string key, string interfaceKey, string surveryKey)
        {
            throw new NotSupportedException("Direct calls are not supported.");
        }

        public void ConfigureExpiryDate(string expiryDateKey, string interfaceKey, string surveyKey, out DateTime expiryDate)
        {
                int days;

                int.TryParse(InterfaceVariables(expiryDateKey, interfaceKey, surveyKey), out days);

                days = days > -1 ? days : 0;

                var thisInstance = DateTime.Now;
                expiryDate = thisInstance.AddDays(days);
        }

        public PortalSnE db { get { return this._DbContext as PortalSnE; } }

        public ProcessManagerRepository(DbContext context, ILogger logger)
        : base(context, logger) { }
    }
    #endregion


    #region EDM/Db Functions 
    public partial class ProcessManagerRepository : RepositoryFactory<WIProcessInstance>, IProcessManager
    {

        //[Watch(For: typeof(InvalidDatabaseOperationException), code: 1055, exception:"There was an error creating a workflow step.Please contact your administrator about this issue.")]
        //public string CreateStepInstance(string flowId, string entityType, string entityId, string sender, string recepient, string completionDateVariable, string completionDateSubVariable, string state, string outcome)
        //{

        //    var instanceId = Guid.NewGuid();

        //    try
        //    {

        //    var entity = new WIProcessInstance
        //    {
        //         //RowGUID        = instanceId,
        //         //ArrivalDate    = DateTime.Now,
        //         //EntityId       = entityId,
        //         //EntityType     = entityType,
        //         //FlowId         = flowId,
        //         //Recepient      = recepient,
        //         //Sender         = sender,
        //         //State          = state,
        //         //TakeOffDate    = DateTime.Now
        //    };

        //    var job = (ExecutionResult)WorkFlowStore.SaveChanges();

        //    return job == ExecutionResult.Success ? instanceId.ToString() : null;
        //    } 
        //    catch
        //    {
        //        throw new InvalidDatabaseOperationException("Failed to create a step instance item.");
        //    }

        //}

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="flowId"></param>
        ///// <param name="entityType"></param>
        ///// <param name="entityId"></param>
        ///// <param name="creator"></param>
        ///// <param name="recepient"></param>
        ///// <param name="state"></param>
        ///// <returns></returns>
        //[Watch(For: typeof(InvalidDatabaseOperationException), code: 1055, exception: "There was an error creating a workflow step.Please contact your administrator about this issue.")]
        //public async Task<string> CreateStepInstanceAsync(string flowId, string entityType, string entityId, string creator, string recepient, string completionDateVariable, string completionDateSubVariable, string state, string outcome)
        //{
        //    var instanceId = Guid.NewGuid();

        //    try
        //    {

        //        var entity = new WIProcessInstance
        //        {
        //            //RowGUID         = instanceId,
        //            //ArrivalDate     = DateTime.Now,
        //            //EntityId        = entityId,
        //            //EntityType      = entityType,
        //            //FlowId          = flowId,
        //            //Recepient       = recepient,
        //            //Sender          = creator,
        //            //State           = state,
        //            //TakeOffDate     = DateTime.Now
        //        };

        //        var job =  (ExecutionResult) await WorkFlowStore.SaveChangesAsync();

        //        return job == ExecutionResult.Success ? instanceId.ToString() : null;
        //    }
        //    catch
        //    {
        //        throw;
        //    }
        //}



        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="precedingStepId"></param>
        ///// <param name="precedingStepInstanceId"></param>
        //public void ConfigureInstancePreceedingStep(string precedingStepId, out string precedingStepInstanceId)
        //{
        //    throw new NotImplementedException();
        //}



    }
    #endregion

}

