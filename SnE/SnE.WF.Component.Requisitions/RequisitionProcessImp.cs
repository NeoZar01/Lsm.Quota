﻿using System.Threading.Tasks;
using System.Collections.Generic;

/// <summary>  
///    The requisition route will allow Schools to make requisitions, and other entities such as Subject Advisors to re-route requsitions and circuit managers to approve them.
/// </summary>
namespace DoE.Lsm.WF.Component.Requisitions
{
    using Api;
    using Logger;
    using Annotations;

    using WI.Api;
    using WI.Tools;

    using Data.Repositories;
    using Monitor.Annotations;
    using Annotations.Exceptions;

    using Service.WI.Proxies;
    using static WF.Component.Requisitions.Role;
    using Steps;
    using SnE.WF.Service.Validation.Api;

    [Interface(Key = "Lsm.Requisitions", Name = "Requisitions - Learning Teaching Support Material")]
    public class RequisitionProcessImp : StepInstanceFactory , NormProcess
    {

        protected readonly ITaskActionWorker      _actionFactory;
        protected readonly Dictionary<string, RequisitionStepAction> processSteps = new Dictionary<string, RequisitionStepAction>();
        protected readonly ValidationCallbacksContainer validationCallbackContainer;

        #region Process Steps
        protected readonly PreliminaryVetting preliminaryVetting;
        protected readonly RimitInstallation  rimitInstallation;
        #endregion

        public override ProcessStepsFactory BeginAction(IStandardNormsRepository normsHandler)
        {
            processSteps[stepName].ProcessRequestedTask(validationCallbackContainer, payload, normsHandler, out outcome);
            return this;
        }

        [Trace(request: "async", estimate: 2)]
        [WatchException(For: typeof(InvalidDatabaseOperationException), code: 1055, exception: "There was an error processing your workflow step instance.Please contact technical support for this issue.")]
        public async Task<ProcessRequestModelProxy> Run(ProcessRequestModelProxy ticket, IStandardNormsRepository standardNormsRepository)
        {
            try
            {
                var stepProcess = await Config(ticket, "enableEscalation:0;escalationPeriod:0;").Start
                                                                                                .PreAction()
                                                                                                .BeginAction(standardNormsRepository)
                                                                                                .PostAction()
                                                                                                .Stop;
                return stepProcess;
            }
            catch
            {
                throw;
            }
        }

        public RequisitionProcessImp(ILogger logger, IRepositoryStoreManager repositoryManager, ITaskActionWorker actionFactory) : base(logger, repositoryManager)
        {
            this._actionFactory         = actionFactory;
            validationCallbackContainer = new ValidationCallbacksContainer();

            processSteps.Add("PreliminaryVetting",  preliminaryVetting   = new PreliminaryVetting(logger, repositoryManager));
            processSteps.Add("RimitInstallation",   rimitInstallation    = new RimitInstallation(logger, repositoryManager));

        }

    }
}