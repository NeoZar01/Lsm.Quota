/// <summary>  
///    The requisition route will allow Schools to make requisitions, and other entities such as Subject Advisors to re-route requsitions and circuit managers to approve them.
/// </summary>
using System.Threading.Tasks;

namespace DoE.Lsm.WF.Component.Requisition
{
    using Core;
    using Logger;
    using WI.Api;
    using WI.Tools;
    using Annotations;
    using WI.Context.Norms;
    using Data.Repositories;
    using Monitor.Annotations;
    using Annotations.Exceptions;

    using static WF.Component.Requisitions.Role;
    using System;
    using WI.Models;

    [FlowProcess(Name = "SNE.Lsm.Requisitions")]
    public class RequisitionsProcess : StepInstanceFactory , NormProcess
    {

        protected readonly IActionTaskFactory      _actionFactory;

        public override ProcessStepsFactory Action(INormInstanceHandler niHandler)
        {
                niHandler.School.ProcessRequestItem();
                return this;
        }

        [Trace(request: "async", estimate: 2)]
        [Watch(For: typeof(InvalidDatabaseOperationException), code: 1055, exception: "There was an error processing your workflow step instance.Please contact technical support for this issue.")]
        public async Task<WorkItemInstance> Activate(Norm payload, INormInstanceHandler niHandler)
        {
            try
            {
                var stepProcess = await Config(payload.ProcessEntityType, payload.Token, "enableEscalation:0;escalationPeriod:0;")
                                       .Start(payload)
                                       .PreAction()
                                       .Action(niHandler)
                                       .End();
                return stepProcess;
            }
            catch
            {
                throw;
            }
        }



        public RequisitionsProcess(ILogger logger, IRepositoryStoreManager repositoryManager, IActionTaskFactory actionFactory) : base(logger, repositoryManager)
        {
            this._actionFactory     = actionFactory;  
        }

    }
}