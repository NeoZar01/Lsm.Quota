using DoE.Lsm.Data.Repositories.EF;
using DoE.Lsm.Data.Repositories;
using DoE.Lsm.Logger;

namespace DoE.Lsm.Data.Repositories.Orders
{
    public class OrderRepository : RepositoryFactory<Inventory> , IOrderRepository
    {

        public OrderRepository(PortalLsm DbContext, ILogger logger):base(DbContext, logger) {}

        //
        /*
         --> Pools a list of orders per grade per bookyear from the vw_rqLimp_OrderItems view
             and re-populate the results into the OrderPerGradeDashboardApp app which then return an IEnumerable list
             of ...
        */
        //public IEnumerable<vw_Inventory> GetOrdersPerGradePerBookYear(int emisCode, int grade, string bookYear)
        //{
        //    return OrderDbContext.vw_Inventory
        //           .Where(c => (c.EmisCode == emisCode) && (c.Grade == grade) && (c.BookYear.Equals(bookYear)))
        //           .OrderBy( c => c.BookYear);
        //}


        //public IQueryable<vw_Inventory> GetOrdersPerGradePerBookYearQueryable(int emisCode, int grade, string bookYear)
        //{
        //    //return OrderSchema.LsmRequisitionItems
        //    //       .Where(c => (c.Emis_Code == emisCode) && (c.Grade == grade) && (c.Bookyear.Equals(bookYear)))
        //    //       .OrderBy(c => c.Grade);                                     

        //    return OrderDbContext.vw_Inventory
        //                      .Where(c => (c.EmisCode == emisCode) && (c.Grade == grade) && (c.BookYear.Equals(bookYear)))
        //                      .OrderBy(c => c.BookYear);
        //}


        //public IEnumerable<InventoryList> GetOrderList(string reqID, string bookYear, int emisCode)
        //{
        //    //add requisition validation 
        //    var orderItemsQuery =  OrderDbContext.Inventories
        //                                      .Where(c => (c.EmisCode == emisCode) && (c.BookYear.Equals(bookYear)))
        //                                      .OrderBy(c => c.BookYear);

        //    foreach (var e in orderItemsQuery)
        //            {
        //                        yield return e;
        //            }
        //}

        //public decimal RequisitionTotalPrice(string reqID)
        //{
        //    try
        //    {
        //        var requisition = OrderDbContext.req_vwRequisitionTotalPrice
        //                                    .Where(c => c.ReqId.Equals(reqID))                                           
        //                                    .SingleOrDefault();
        //        return requisition.TotalPrice ?? 0.0M ;
        //    }
        //    catch
        //    {
        //        return 0.0M;
        //    }
        //}

        public PortalLsm OrderDbContext { get { return this._DbContext as PortalLsm; } }
    }
}