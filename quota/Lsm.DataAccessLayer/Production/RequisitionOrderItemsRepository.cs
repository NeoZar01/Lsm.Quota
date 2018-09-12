using DoE.Lsm.Data.Repositories.EF;
using DoE.Lsm.Logger;
using DoE.Lsm.Data.Repositories.Order;

namespace DoE.Lsm.Data.Repositories.Orders
{
    public class RequisitionOrderItemsRepository : Repository<vw_RequisitionOrderItems>, IRequisitionOrderItemsRepository
    {
        public RequisitionOrderItemsRepository(PortalLsm context, ILogger logger) : base(context, logger){}


/*
     This turns to return duplicates due to requisition Id not being part of the primary-composite-key
     ---> grouping by requisition emisCode resolves this error
*/

        //public IEnumerable<vw_ShoppingCardItems> GetRequisitionOrderOItems(string reqId, int emisCode, string bookYear)
        //{
        //    var query = from item in Db.vw_ShoppingCardItems
        //                where item.EmisCode == emisCode && item.BookYear.Equals(bookYear) && item.ReqId.Equals(reqId)
        //                group item by item.ISBN into orderItems
        //                orderby orderItems.Key
        //                select orderItems;

        //    return RequisitionOrderItemsIterator(query);
        //}

        ////This may not be accurate due to duplicate values.
        //public decimal GetRequisitionOrderTotalPrice(string reqId, int emisCode, string bookYear)
        //{

        //    var orderItemsGroup = from item in Db.vw_ShoppingCardItems              
        //                          where item.EmisCode == emisCode && item.BookYear.Equals(bookYear) && item.ReqId.Equals(reqId)
        //                           group item by item.ISBN into orderItems
        //                          orderby orderItems.Key
        //                          select orderItems;

        //     var totalPrice = RequisitionOrderItemsIterator(orderItemsGroup).Sum( c=> c.TotalPrice);
        //     return ((decimal?)totalPrice) ?? 0.0M; 

        //}

        //public PortalLsm Db { get { return this._DbContext as PortalLsm; } }


        //protected virtual IEnumerable<vw_ShoppingCardItems> RequisitionOrderItemsIterator( IOrderedQueryable<IGrouping<string, vw_ShoppingCardItems>> orderItemsPerId)
        //{

        //    foreach(var orderItemsGroup in orderItemsPerId)
        //    {
        //        var orderItems = orderItemsGroup.OrderBy( c=> c.Grade); //reorder the results by grade

        //        foreach (var item in orderItems)
        //        {
        //            yield return item;
        //        } 
        //    }            

        //}
    
    }
}
