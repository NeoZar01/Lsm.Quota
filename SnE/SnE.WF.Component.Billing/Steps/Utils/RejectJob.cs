using System;
using System.Threading.Tasks;

namespace DoE.Lsm.WF.Component.Requisition.Steps
{
    using Requisitions.Factories;

    public sealed class RejectJob : RejectFactory
    {

        //public RejectJob(string requisition, IDbConnector WFDbContext) : base(requisition , WFDbContext) {}


        //public override Reject ChangeState(WF.Read readType)
        //{

        //    int changerequisitionTask = WFDbContext.Requisitions.MoveInstanceToAnotherState(WFDbContext.Requisitions.GetRequisitionByEntityId(requisition), (byte)global::WF.Scheme.WF.Activity.Deny);

        //    if (changerequisitionTask == 0)
        //    {
        //        throw new Exception("Failed to change requisition state");
        //    }
        //    return this;
        //}


        //public override Reject CreateTL(global::WF.Scheme.WF task, WF.Read readType)
        //{
        //    var workFlow = WFDbContext.WF.GetWFTicket(task.Receiver, requisition);

        //    var WFTimeline = new DoE.Data.Repository.EF.WorkFlowTimeLine
        //                    {
        //                         Activity  = (int)task.Action,
        //                         CreationDate = DateTime.Now,
        //                         From = task.Sender,
        //                         To = task.Receiver,
        //                         Description = "Rejected Requisition",
        //                         FromDescription = task.SenderName,
        //                         ToDescription = task.ReceiverName,
        //                         Task = 1,
        //                         WorkId = workFlow.id
        //                        };



        //   int addTask = WFDbContext.WFTimeLine.SaveWFTimeLine(WFTimeline);

        //    if (addTask == 0)
        //    {
        //        throw new Exception("Failed to save timeline");
        //    }

        //    var WFTimelineEntity = WFDbContext.WFTimeLine.GetWFTimelineWithTransactionOptions(WFId: workFlow.id, sendFrom: task.Sender, receivedBy: task.Receiver , read: readType);

        //    WFTimeLineId = WFTimelineEntity.id;

        //    return this;
        //}


        //public override Reject SaveMessage(global::WF.Scheme.WF task, string message)
        //{

        //    var WFTimeLineMessage = new  DoE.Data.Repository.EF.WorkFlowTicketMessage
        //                            {
        //                                 CreationDate =  DateTime.Now,
        //                                 From =  task.Sender,
        //                                 FromDescription = task.SenderName,
        //                                 To = task.Receiver,
        //                                 ToDescription = task.ReceiverName,
        //                                 IsActive = true,
        //                                 LastModifiedDate = DateTime.Now,
        //                                 Message =  message,
        //                                 Ticket = WFTimeLineId,
        //                            };

        //    int saveWFMessageTask = WFDbContext.WFMessages.SaveWorkFlowMessage(WFTimeLineMessage);

        //    if(saveWFMessageTask == 1)
        //    {
        //        return this;
        //    }
        //        throw new Exception("Failed To Save Data");
        //}

        //#region --->Async Methods

        //public async override Task<Reject> ChangeStateAsync(WF.Read transRead)
        //{

        //    var changerequisitionTask = await WFDbContext.Requisitions.MoveInstanceToAnotherStateAsync(WFDbContext.Requisitions.GetRequisitionByEntityId(requisition), (byte)global::WF.Scheme.WF.Activity.Deny);

        //    if (changerequisitionTask == WF.Task.Failed)
        //    {
        //        throw new Exception("Failed to change requisition state");
        //    }
        //    return this;
        //}

        //#endregion


        //public override Task<Reject> SaveMessageAsync(Scheme.WF task, string message)
        //{throw new NotImplementedException();}

        //public override Task<Reject> CreateTLAsync(global::WF.Scheme.WF task, WF.Read readType)
        //{throw new NotImplementedException();}

    }
}
