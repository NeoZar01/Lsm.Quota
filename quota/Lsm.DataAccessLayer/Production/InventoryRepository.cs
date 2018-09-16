using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace DoE.Lsm.Data.Repository.Inventories
{

    using Logger;
    using Annotations;
    using Annotations.Exceptions;
    using Repositories;
    using Repositories.EF;
    using WF.Engine.Context;

    public class InventoryRepository : RepositoryFactory<Inventory> , IInventoryRepository 
    {

        public InventoryRepository(PortalLsm DbContext, ILogger logger) :base(DbContext, logger) {}

        #region Inventory List
        public IEnumerable<string> InventoryItemsNames([Column(Calendar = Column.Fact.IsRequired)]int emisCode, string keyword, string bookYear)
        {

            var searchQuery = (from k in DbContext.vw_Inventory 
                               where
                               (k.EmisCode == emisCode && k.BookYear.Equals(bookYear)) && k.BookName.Contains(keyword) || k.ISBN.Contains(keyword)
                              || k.Author.Contains(keyword) || k.SubjectName.Equals(keyword)
                               select k)
                              .OrderBy(c => c.Grade)
                              .OrderBy( c => c.BookName)
                              .Select(c => c.BookName);

            foreach (var i in searchQuery)
            {
                yield return i;
            }
        }

         /**
          *
          */
         // <summary>
         //
         // </summary>
        public async Task<ExecutionResult> UpdateAsync(Inventory item, int qty, int quota)
        {

            item.Quantity         = item.Quantity + (quota - qty);
            item.LastModifiedDate = DateTime.Now;

            var exec = await _DbContext.SaveChangesAsync();

            if ((ExecutionResult)exec == ExecutionResult.Success) return ExecutionResult.Success;

            throw new InvalidDatabaseOperationException();
        }

        /**
         *
         */
        // <summary>
        //
        // </summary>
        public IEnumerable<vw_Inventory> List([Column(Calendar = Column.Fact.IsRequired)]int emisCode, string keyword, string bookYear)
        {

            var searchQuery = (from k in DbContext.vw_Inventory
                               where
                              (k.EmisCode == emisCode && k.BookYear.Equals(bookYear)) && k.BookName.Contains(keyword) || k.ISBN.Contains(keyword) || k.Author.Contains(keyword) || k.SubjectName.Equals(keyword)
                               select k)
                              .OrderBy(c => new { c.Grade , c.BookName });

            foreach (var book in searchQuery)
            {
                yield return book;
            }
        }
        #endregion

        #region Inventory Requests
        /**
         *
         */
        // <summary>
        //
        // </summary>
        public async Task<ExecutionResult> SaveListItemAsync(string reqId, string invInstanceId, InventoryRequest invRequest)
        {

            invRequest.ReqId            = reqId;
            invRequest.InvBarCode       = invInstanceId;

            invRequest.LastModifiedDate = DateTime.Now;
            invRequest.CreationDate     = DateTime.Now;

            DbContext.InventoryRequests.Add(invRequest);

            try
            {
                await DbContext.SaveChangesAsync();
                return ExecutionResult.Success;
            }
            catch 
            {
                throw;
            }

        }
        #endregion

        /**
         *  
         */
        // <summary>
        //  <value> converts and returns the <c>__DbContext</c> into <c>PortalLsm</c> </value>
        // </summary>
        public PortalLsm DbContext { get { return this._DbContext as PortalLsm; } }

    }
}
