/**
 *
 */
///<summary>
///
///</summary>
namespace DoE.Lsm.Data.Repository.Inventories
{
    using System.Threading.Tasks;
    using System.Collections.Generic;

    using DoE.Lsm.WF.Engine.Context;
    using DoE.Lsm.Data.Repositories;
    using Repositories.EF;

    public interface IInventoryRepository : IRepository<Inventory>
    {
        /**
         *  Gets the names of items in the inventory list.
         */
        ///<summary>
        /// Gets the names of items in the inventory list.
        ///</summary>
        IEnumerable<string>         InventoryItemsNames(int emisCode, string keyword, string bookYear);

        /**
         *  Gets an inventory list.
         */
        ///<summary>
        /// Gets an inventory list.
        ///</summary>
        IEnumerable<vw_Inventory>   List(int emisCode, string keyword, string bookYear);

        /**
         *   Updates an inventory item
         */
        ///<summary>
        ///   Updates an inventory item
        ///</summary>
        Task<ExecutionResult> UpdateAsync(Inventory inventory , int qty, int enr);

        /**
         *  Updates an inventory item
         */
        ///<summary>
        /// Updates an inventory item
        ///<remark>
        ///  First 2 paramenters ensures that all referencial integrity rules are satisfied.
        ///</remark>
        ///<param name="reqId">Requisition Reference Number</param>
        ///<param name="invInstanceId"> Requisition Item Id</param>
        ///<param name="invQty"> Inventory Request Object</param>
        ///</summary>
        Task<ExecutionResult> SaveListItemAsync(string reqId , string invInstanceId, InventoryRequest invRequest);
    }

}
