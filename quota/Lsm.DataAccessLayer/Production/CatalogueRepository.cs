
using System.Collections.Generic;
using System.Linq;
using DoE.Lsm.Logger;
using DoE.Lsm.Annotations;
using DoE.Lsm.Data.Repositories.EF;
using DoE.Lsm.Data.Repository.Catalogue;

namespace DoE.Lsm.Data.Repositories.Catalogue
{
    public class CatalogueRepository : RepositoryFactory<vw_Inventory> , ICatalogueRepository
    {

        public CatalogueRepository(PortalLsm DbContext, ILogger logger) : base(DbContext, logger)
        {}


        public IEnumerable<string> GetBooks([Column(Calendar = Column.Fact.IsRequired)]int id, string keyword, string bookYear)
        {

            var searchQuery = (from k in Container.vw_Inventory
                               where
                               (k.EmisCode == id && k.BookYear.Equals(bookYear)) && k.BookName.Contains(keyword) || k.ISBN.Contains(keyword)
                              || k.Author.Contains(keyword) || k.SubjectName.Equals(keyword)
                               select k)
                              .OrderBy(c => c.Grade)
                              .Select(c => c.BookName);

            foreach (var book in searchQuery)
            {
                yield return book;
            }
        }

       public PortalLsm Container { get { return this._DbContext as PortalLsm;  } }



//        public string GetDefaultSubjectsFilterFormatter([Term(BookYear = Term.Parameter.Mandatory)]int emisCode, string keyword , string bookYear)
//        {

//            string defaultSubjectFilter = null;

//// ---> Can alternatively use group-by clause here
//            var searchQuery = (from k in Container.vw_Inventory
//                               where ( k.EmisCode == emisCode && k.BookYear.Equals(bookYear)) && k.BookName.Contains(keyword) || k.ISBN.Contains(keyword)
//                                                     || k.Author.Contains(keyword) || k.SubjectName.Equals(keyword)
//                               select k)
//                              .OrderBy(c => c.SubjectName)
//                              .Select(c => c.SubjectName)
//                              .Distinct()
//                              .Take(1);

//                        foreach(var s in searchQuery)
//                            {
//                                    defaultSubjectFilter = s;
//                            }

//            return defaultSubjectFilter; 
//        }


//        public IEnumerable<string> GetSubjectsFilterFormatter([Term(BookYear = Term.Parameter.Mandatory)]int emisCode, string keyword, string bookYear)
//        {
//            var searchQuery = (from k in Container.vw_Inventory
//                               where (k.EmisCode == emisCode && k.BookYear.Equals(bookYear)) && k.BookName.Contains(keyword) || k.ISBN.Contains(keyword)
//                                                     || k.Author.Contains(keyword) || k.SubjectName.Equals(keyword)
//                               select k)
//                              .OrderBy(c => c.SubjectName)
//                              .Select(c => c.SubjectName).Distinct();
//            return searchQuery;
//        }


//        public async Task<int> SetItemToBookmarkedRegistryAsync(int emisCode)
//        {
//            using ( var transaction  =  Container.Database.BeginTransaction())
//            {
//                try
//                {
//                    //var e = await Container.LsmRequisitionItems.FindAsync(emisCode);
//                    //if (e != null)
//                    //{
//                    //    e.IsBookmarked = true;
//                    //    e.LastModifiedDate = DateTime.Now;

//                    //    await Container.SaveChangesAsync();
//                    //    transaction.Commit();
//                    //    return 1;
//                    //}
//                }
//                catch
//                {
//                    transaction.Rollback();
//                }

//                return 0;
//            }
//        }//---> These bookmarks an item from the catalogue list.


//        public async Task<int> RemoveItemFromBookmarkRegistryAsync(int emisCode)
//        {
//            using (var transaction = Container.Database.BeginTransaction())
//            {
//                try
//                {
//                    //var e = await Container.LsmRequisitionItems.FindAsync(emisCode);
//                    //if (e != null)
//                    //{
//                    //    e.IsBookmarked = false;
//                    //    e.LastModifiedDate = DateTime.Now;

//                    //    await Container.SaveChangesAsync();
//                    //    transaction.Commit();
//                    //    return 1;
//                    //}
//                }
//                catch
//                {
//                    transaction.Rollback();
//                }

//                return 0;
//            }
//        }//---> These removes an item from the bookmark list.


//        //public vw_Inventory GetCatalogueItem(int emisCode)
//        //{
//        //    return Container.vw_Inventory.Where( c => c.Id == emisCode).SingleOrDefault();
//        //}

//        public IPagedList<vw_RequisitionOrderItems> GetBookmarks(int emisCode, string bookYear, int? page)
//        {
//            int pageSize = 10;
//            int pageNumber = (page ?? 1);

//            var catalogueSearchQuery = Container.vw_RequisitionOrderItems
//                     .Where(c => c.EmisCode == emisCode && c.BookYear.Equals(bookYear) && c.IsBookmarked && c.IsActive).OrderBy(c => c.Grade);

//            return catalogueSearchQuery.ToPagedList(pageNumber, pageSize);
//        }



//        public IEnumerable<string> GetTopBooks([Term(BookYear = Term.Parameter.Mandatory)]int emisCode, string keyword, string bookYear, int count)
//        {
//            var searchQuery = (from k in Container.vw_Inventory
//                               where
//                               ( k.EmisCode == emisCode && k.BookYear.Equals(bookYear)) && k.BookName.Contains(keyword) || k.ISBN.Contains(keyword)
//                              || k.Author.Contains(keyword) || k.SubjectName.Equals(keyword)
//                               select k)
//                            .OrderBy(c => c.Grade)
//                            .Take(count)
//                            .Select(c => c.BookName);

//            foreach (var book in searchQuery)
//            {
//                yield return book;
//            }
//        }


//        //public IEnumerable<vw_Inventory> GetBooksSharingSimilarAttributes([Fact(BookYear = Fact.Parameter.Mandatory)]vw_Inventory item , int count)
//        //{
//        //    var booksSharingSimilarAttributesQuery = Container.vw_Inventory
//        //                    .Where(c => ( c.Entity.Equals(item.Entity) && c.Language.Equals(item.Language) && (c.emisCode != item.emisCode) && (c.EmisCode == item.EmisCode) && c.BookYear.Equals(item.BookYear)))
//        //                    .OrderBy(c => c.Grade)
//        //                    .Take(count);

//        //       foreach( var book in booksSharingSimilarAttributesQuery)
//        //       {
//        //                       yield return book;
//        //       }
//        //}

//        public Task<IPagedList<vw_RequisitionOrderItems>> GetBooksByPagingAsync(int emisCode, string keyword, int? page, string bookYear)
//        {
//            throw new NotImplementedException();
//        }

//        public IPagedList<vw_RequisitionOrderItems> GetBooksByPaging(int emisCode, string keyword, int? page, string bookYear)
//        {

//            int pageSize = 15;
//            int pageNumber = (page ?? 1);

//            var searchQuery = (from k in Container.vw_RequisitionOrderItems
//                               where
//                               (k.IsActive && k.EmisCode == emisCode && k.BookYear.Equals(bookYear)) && k.ItemName.Contains(keyword) || k.ISBN.Contains(keyword)
//                              || k.Author.Contains(keyword) || k.SubjectName.Equals(keyword)
//                               select k)
//                              .OrderBy(c => c.Grade);
//            return searchQuery.ToPagedList(pageNumber, pageSize);
//        }

//        public IPagedList<vw_RequisitionOrderItems> GetOrderedItems(int emisCode, string keyword, string bookYear, int? page)
//        {
//            try
//            {

//            int pageSize = 8;
//            int pageNumber = (page ?? 1);

//            var orderItemsQuery = (from k in Container.vw_RequisitionOrderItems
//                                   where (k.EmisCode == emisCode && k.BookYear.Equals(bookYear)) && (k.ItemName.Contains(keyword) || k.ISBN.Contains(keyword)
//                                  || k.Author.Contains(keyword) || k.SubjectName.Equals(keyword))
//                                   select k)
//                              .OrderByDescending(c => c.Available2);

//            return orderItemsQuery.ToPagedList(pageNumber, pageSize);

//            }catch(Exception e)
//            {
//                throw new EntityNotFoundException(e.Message, "Unable to load ordered items", " ", Container.req_vwOrderItems, emisCode, true, Severity.High.No);
//            }

//        }
    }
}