using DoE.Lsm.Data.Repositories.EF;

namespace DoE.Lsm.Data.Repositories.Order
{

    public interface IRequisitionOrderItemsRepository :  IRepository<vw_RequisitionOrderItems>
    {
        //IEnumerable<vw_ShoppingCardItems> GetRequisitionOrderOItems(string ReqId, int emisCode , string bookYear);
        //decimal GetRequisitionOrderTotalPrice(string reqId, int emisCode, string bookYear);
    }
}
