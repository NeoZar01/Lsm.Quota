namespace DoE.Lsm.Data.Repository.Catalogue
{
    using Repositories.EF;
    using Repositories;

    public interface ICatalogueRepository : IRepository<vw_Inventory>
    {
                
        //IEnumerable<string> GetTopBooks(int emisCode, string keyword, string bookYear , int count);
        
        //IEnumerable<string> GetSubjectsFilterFormatter(int emisCode, string keyword , string bookYear);
        
        //IPagedList<vw_RequisitionOrderItems> GetBookmarks([Term(BookYear = Term.Parameter.Mandatory)]int emisCode , string bookYear , int? page);

        ////IEnumerable<vw_Inventory> GetBooksSharingSimilarAttributes(vw_Inventory item , int count);
        
        //string GetDefaultSubjectsFilterFormatter(int emisCode, string keyword, string bookYear);
        
        //IPagedList<vw_RequisitionOrderItems> GetBooksByPaging([Term(BookYear = Term.Parameter.Mandatory)]int emisCode, string keyword, int? page, string bookYear);

        //IPagedList<vw_RequisitionOrderItems> GetOrderedItems([Term(BookYear = Term.Parameter.Mandatory)]int emisCode, string keyword, string bookYear, int? page);

        //Task<int> SetItemToBookmarkedRegistryAsync(int emisCode);

        //Task<int> RemoveItemFromBookmarkRegistryAsync(int emisCode);

        ////vw_Inventory GetCatalogueItem(int emisCode);

    }
}
