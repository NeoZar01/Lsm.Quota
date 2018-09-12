using DoE.Lsm.Data.Repositories;
using DoE.Lsm.Data.Repositories.EF;

namespace DoE.Lsm.Data.Repositories.Orders
{
    public interface IOrderRepository : IRepository<Inventory>
    {        
        //IEnumerable<vw_Inventory> GetOrdersPerGradePerBookYear([Term(BookYear = Term.Parameter.Mandatory)] int emisCode, int grade, string bookYear);
        //IQueryable<vw_Inventory> GetOrdersPerGradePerBookYearQueryable([Term(BookYear = Term.Parameter.Mandatory)]int emisCode, int grade, string bookYear);        
        //IEnumerable<InventoryList> GetOrderList([Term(BookYear = Term.Parameter.Mandatory)] string reqID, string bookYear, int emisCode);
        //decimal RequisitionTotalPrice(string reqID);
    }
}
