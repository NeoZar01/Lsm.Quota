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
    using Service.WI.Proxies;

    public abstract class StepInstanceFactory : ProcessStepsFactory
    {

        public string preceedingStepId          = "";
        public string preceedingStepInstanceId  = "";
        public string currentStepInstanceId     = "";
        public string stepName                  = "";
        public string outcome                   = "";

        protected ProcessInstance   processOutcome;
        protected IStepInstanceRule escalationRule;

        public ProcessRequestModelProxy payload;


        public override ProcessStepsFactory Config(ProcessRequestModelProxy model, string command)
        {
             escalationRule = new StepRuleInstallationWorker(model.EntityType, _repositoryManager).EscationRules(Command.ResolveCommandExpressions(@"([1-9][0-9]{0,2});", command, "enableEscalation", "escalationPeriod"));

            _repositoryManager.Processes.SetupProcessStep(model.ProcessInstanceId, out preceedingStepId, out preceedingStepInstanceId);

            if(preceedingStepId.Equals("") || preceedingStepInstanceId.Equals(""))
            {
                throw new FailedBatchTransactionException("Failed to initialise global variables for the preceeding step");
            }

            _repositoryManager.Processes.CreateInstanceSnapShot<ProcessRequestModelProxy>(model, currentStepInstanceId, preceedingStepId, preceedingStepInstanceId, model.PersonId, model.EntityId, model.EntityType,
                        model.param_001, model.param_002, model.param_003, model.param_004, model.param_005, model.param_006, model.param_007, model.param_008, model.param_009, model.param_0010);

            payload = model;

            return this;
        }

        public override ProcessStepsFactory Start
        {
            get
            {

                return this;
            }
        }

        public override Task<ProcessRequestModelProxy> Stop
        {
            get
            {
                return null;    
            }
        }

        public override ProcessStepsFactory BeginAction(IStandardNormsRepository niHandler)
        {
            return action.Invoke;
        }

        public override ProcessStepsFactory PreAction() {
                 action = new Action(_repositoryManager).GetWorker(this.stepName, this.preceedingStepId, this.preceedingStepInstanceId, this.currentStepInstanceId);
            return this;
        }

        public override ProcessStepsFactory  PostAction()
        {
            return this;
        }

        public StepInstanceFactory(ILogger logger, IRepositoryStoreManager repositoryManager) : base(logger, repositoryManager){}

    }
}
