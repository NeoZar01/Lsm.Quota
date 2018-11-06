using System;
using System.Threading.Tasks;

namespace DoE.Lsm.WF.Engine.WI.Tools
{
    using Logger;
    using Context;
    using Annotations.Exceptions;
    using Data.Repositories;
    using Service.WorkItem.Api;
    using Engine.Context;

    public abstract class StepInstanceFactory : ProcessStepsFactory
    {

        public string preceedingStepId         = "";
        public string preceedingStepInstanceId = "";
        public string currentStepInstanceId     = "";

        protected ProcessInstance   processOutcome;
        protected IStepInstanceRule escalationRule;

        public ProcessWorkItem _payload;


        public StepInstanceFactory(ILogger logger, IRepositoryStoreManager dataStoreManager) : base(logger, dataStoreManager) {}

        /// <summary>
        ///     This method does the following
        ///     > Get the current step which the item is residing....
        ///     > Prepares the preceeding step - <c>initialise preceedingStepId</c> with the thrown Id and returns the ProcessStepFactory
        /// </summary>
        /// <param name="entityType"></param>
        /// <param name="instanceCaseId"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        public override ProcessStepsFactory Config(string entityType, string instanceCaseId, string command)
        {
            if (string.IsNullOrEmpty(instanceCaseId))  throw new ArgumentNullException(nameof(instanceCaseId));

            escalationRule = new StepRuleInstallationWorker(entityType, _dataStoreManager).EscationRules(Command.ResolveCommandExpressions(@"([1-9][0-9]{0,2});", command, "enableEscalation", "escalationPeriod"));

            _dataStoreManager.WI.ProcessInstanceParkingStep(instanceCaseId, out preceedingStepId, out preceedingStepInstanceId);

            if(preceedingStepId.Equals("") || preceedingStepInstanceId.Equals(""))
            {
                throw new FailedTransactionException("Failed to initialise global variables for the preceeding step");
            }
            return this;
        }

        /// <summary>
        ///     Creates a snapshot of the payload
        /// </summary>
        /// <returns></returns>        
        public override ProcessStepsFactory PreStart(ProcessWorkItem payload)
        {
            if (payload == null) throw new ArgumentNullException(nameof(payload));
            if (_dataStoreManager == null) throw new ArgumentNullException(nameof(_dataStoreManager));

            _dataStoreManager.WI.CreateInstanceSnapShot<ProcessWorkItem>(payload, currentStepInstanceId, preceedingStepId, preceedingStepInstanceId, payload.IdentityToken, payload.ProcessInstanceId, payload.InstanceEntityType,
                                    payload.param_001, payload.param_002, payload.param_003, payload.param_004, payload.param_005, payload.param_006, payload.param_007, payload.param_008, payload.param_009, payload.param_0010);

            _payload = payload;

            return this;
        }

        public override ProcessStepsFactory Start() {
            return this;
        }

        public override ProcessStepsFactory ExecuteAction()
        {
            return this;
        }

        public override ProcessStepsFactory Process(ProcessWorkItem payload)
        {
            return this;
        }

        public override Task<ProcessStepsFactory> End()
        {
            return null;
        }
    }
}
