using System;
using System.Threading.Tasks;

namespace DoE.Lsm.WF.Component.Requisition.Tasks
{
    using Requisitions.Factories;

    public class Submit : SubmitFactory
    {
    //    public Submit(string requisition, IDbConnector wfDbContext) : base(requisition, wfDbContext){}



    //    public override SubmitJob ChangeState(WF.Read readType)
    //    {
    //        var changeStateTask =  this.WFDbContext.Requisitions.MoveInstanceToAnotherState(WFDbContext.Requisitions.GetRequisitionByEntityId(requisition), (byte)global::WF.Scheme.WF.Activity.Submit);

    //        if(changeStateTask == WF.Task.Succeeded)
    //        {
    //            return this;
    //        }
    //        throw new Education.Repository.Exceptions.InstanceNotFoundException();
    //    }




    //    public override SubmitJob CreateWFTicket(global::WF.Scheme.WF task)
    //    {

    //        var WFTicket = WFDbContext.WF.GetWFByRequisition(requisition);

    //        if(WFTicket == null)
    //        {
    //            var WFEntity = new WorkFlow
    //                            {
    //                                CreationDate = DateTime.Now,
    //                                LastModifiedDate = DateTime.Now,
    //                                Ref = requisition,
    //                                From = task.Sender,
    //                                FromDescription = task.SenderName,
    //                                To = task.Receiver,
    //                                ToDescription = task.ReceiverName,
    //                                IsActive = true,
    //                                IsApproved = false
    //                            };

    //            var WFItem =  WFDbContext.WF.SaveWF(WFEntity, WF.Read.Clean);

    //            if(WFItem == null)
    //            {
    //                throw new Education.Repository.Exceptions.InstanceNotFoundException();
    //            }
    //             WFId = WFItem.id;
    //             return this;
    //        }

    //        WFId = WFTicket.id;
    //        WFTicket.LastModifiedDate = DateTime.Now;

    //       int updateWFTLTask =  WFDbContext.WF.UpdateWFTimeLine(WFTicket);

    //        if (updateWFTLTask == 1)
    //        {
    //            return this;
    //        }
    //        throw new Education.Repository.Exceptions.InstanceNotFoundException();
    //    }

    //    public override async Task<SubmitJob> CreateTLAsync(global::WF.Scheme.WF task, WF.Read readType)
    //    {

    //        var WFTimeLine = new WorkFlowTimeLine
    //                            {
    //                                Activity = (int)task.Action,
    //                                CreationDate = DateTime.Now,
    //                                From = task.Sender,
    //                                To = task.Receiver,
    //                                FromDescription = task.SenderName,
    //                                ToDescription = task.ReceiverName,
    //                                Task = 1,
    //                                WorkId = this.WFId,
    //                                Description = string.Concat("At ", DateTime.Now, " ", string.Concat(task.SenderName, " | ", task.Sender), " Submitted A Requisition To ", string.Concat(task.SenderName, " | ", task.Sender))
    //                            };

    //        var saveTask = await WFDbContext.WFTimeLine.SaveWFTimeLineAsync(WFTimeLine);

    //        if(saveTask == 1)
    //        {
    //            this.job = 1;
    //            return this;
    //        }
    //        throw new InstanceNotSavedException<WorkFlowTimeLine>("");
    //    }


    //    public override Task<SubmitJob> ChangeStateAsync(WF.Read readType)
    //    { throw new NotImplementedException(); }

    //    public override Task<SubmitJob> CreateWFTicketAsync(global::WF.Scheme.WF task)
    //    { throw new NotImplementedException(); }

    //    public override SubmitJob CreateTL(global::WF.Scheme.WF task, WF.Read readType)
    //    { throw new NotImplementedException(); }


    }
}
