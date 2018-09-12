using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DoE.Lsm.ShoppingCard.Api
{
    using Annotations;
    using Data.Repositories.EF;

    public interface ICardRepository
    {

        /**
         * 
         */
        ///<summary> 
        ///      Adds a new entity into the shopping card
        ///</summary>
        Task<int> AddToCard(Guid instanceId, string reqNo, int id, int qty, School school, byte minGrade, byte maxGrade, string stage, string state);

        /**
         * 
         */
        ///<summary>
        ///      Pools a list of all items in the card
        ///</summary>
        IEnumerable<vw_ShoppingCardItems> ItemList(string reqId, int id);

        /**
         * 
         */
        ///<summary>
        ///     Checkout to rimit process
        ///</summary>
        Task<int> CheckOut(string entityId, int sender, int receiver);

        /**
         * 
         */
        ///<summary>
        ///      Gets the total price of the card.
        ///</summary>
        decimal GetTotalPrice<T>([InstanceEntityType(options: "REQUISITIONS, ORDERS")]string entityType, string entityId, int id) where T : class;

        /**
         * 
         */
        ///<summary>
       ///      Remove an item from the car list.
       ///</summary>
        void RemoveItem([InstanceEntityType(options: "REQUISITIONS, ORDERS")]string entityType , string entityId , string itemId );

    }
}