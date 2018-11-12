using System;
using System.Threading.Tasks;

namespace DoE.Lsm.WF.WI.Tools
{
    using Api;
    using Logger;
    using Annotations.Exceptions;
    using Core;
    using Engine.Service.WorkItem.Api;
    using Data.Repositories;
    using Context.Norms;
    using Models;

    public abstract class StepInstanceFactory : ProcessStepsFactory
    {

        public string preceedingStepId          = "";
        public string preceedingStepInstanceId  = "";
        public string currentStepInstanceId     = "";
        public string StepName                  = "";

        protected ProcessInstance   processOutcome;
        protected IStepInstanceRule escalationRule;

        public Norm _payload;

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

            escalationRule = new StepRuleInstallationWorker(entityType, _repositoryManager).EscationRules(Command.ResolveCommandExpressions(@"([1-9][0-9]{0,2});", command, "enableEscalation", "escalationPeriod"));

            _repositoryManager.WI.ProcessInstanceParkingStep(instanceCaseId, out preceedingStepId, out preceedingStepInstanceId);

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
        public override ProcessStepsFactory Start(Norm payload)
        {
            if (payload == null) throw new ArgumentNullException(nameof(payload));
            if (_repositoryManager == null) throw new ArgumentNullException(nameof(_repositoryManager));

            _repositoryManager.WI.CreateInstanceSnapShot<Norm>(payload, currentStepInstanceId, preceedingStepId, preceedingStepInstanceId, payload.ClaimsToken, payload.ProcessEntityId, payload.ProcessEntityType,
                                    payload.param_001, payload.param_002, payload.param_003, payload.param_004, payload.param_005, payload.param_006, payload.param_007, payload.param_008, payload.param_009, payload.param_0010);

            _payload = payload;

            return this;
        }

        public override ProcessStepsFactory Action(INormInstanceHandler niHandler)
        {
            return action.Invoke;
        }

        public override ProcessStepsFactory PreAction() {
                 action = new Action(_repositoryManager).GetWorker(this.StepName, this.preceedingStepId, this.preceedingStepInstanceId, this.currentStepInstanceId);
            return this;
        }

        public override Task<WorkItemInstance> End()
        {
            return null;
        }

        public StepInstanceFactory(ILogger logger, IRepositoryStoreManager repositoryManager) : base(logger, repositoryManager){}

    }
}
