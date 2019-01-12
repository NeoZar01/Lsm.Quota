namespace DoE.Lsm.WF.Component.Requisition.Steps
{
    using Requisitions.Factories;

    public sealed class Accept : AcceptFactory
    {

    //    public Accept(string requisition, IDbConnector WFDbContext) : base(requisition, WFDbContext){}


    //    public override AcceptJob ChangeStep(WF.Read readType)
    //    {

    //        int changeStateTask = WFDbContext.Requisitions.MoveInstanceToAnotherState(WFDbContext.Requisitions.GetRequisitionByEntityId(requisition), (byte)global::WF.Scheme.WF.Activity.Approve);

    //        if (changeStateTask == 0)
    //        {
    //            throw new Exception("Failed to change requisition state"); // WFExcetion should be implemented.
    //        }
    //        return this;
    //    }


    //    public override AcceptJob CreateTL(global::WF.Scheme.WF task, WF.Read readType)
    //    {

    //        var WFEntity = WFDbContext.WF.GetWFByRequisition(requisition);

    //        if (WFEntity != null)
    //        {
    //            var WFTimeLineEntity = new DoE.Data.Repository.EF.WorkFlowTimeLine
    //                                        {
    //                                             Activity =(int) task.Action,
    //                                             CreationDate = DateTime.Now,
    //                                             From = task.Sender,
    //                                             FromDescription = task.SenderName,
    //                                             To = task.Receiver,
    //                                             ToDescription = task.ReceiverName,
    //                                             WorkId = WFEntity.id,
    //                                             Description = string.Concat("At " , DateTime.Now, string.Concat(task.SenderName , " | " , task.SenderName) , " Accepted Requisition With Reference ", requisition, " From ", string.Concat(task.ReceiverName) , " | ", task.Receiver),
    //                                             Task = (int)global::WF.Scheme.WF.Type.Requisition                    
    //                                        };

    //            int saveTimeLineTask = WFDbContext.WFTimeLine.SaveWFTimeLine(WFTimeLineEntity);

    //            if( saveTimeLineTask == 1)
    //            {
    //                return this;
    //            }
    //            throw new InstanceNotFoundException();
    //        }

    //            throw new InstanceNotFoundException();

    //    }

    //    public override AcceptJob GetWFItems()
    //    {throw new NotImplementedException();}

    //    public override AcceptJob ProcessWFItems()
    //    {throw new NotImplementedException();}

    //    #region ---> Unused Implementations
    //    public override Task<AcceptJob> ProcessWFItemsAsync()
    //    {throw new NotImplementedException();}

    //    public override Task<AcceptJob> GetWFItemsAsync(string requisitionId)
    //    {throw new NotImplementedException();}

    //    public override Task<AcceptJob> ChangeRequisitionStateAsync(WF.Read readType)
    //    {throw new NotImplementedException();}

    //    public override Task<AcceptJob> CreateWorkFlowTimeLineAsync(global::WF.Scheme.WF task, WF.Read readType)
    //    {throw new NotImplementedException();}
    //    #endregion 

    }
}
