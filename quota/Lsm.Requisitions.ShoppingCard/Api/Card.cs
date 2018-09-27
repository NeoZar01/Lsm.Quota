using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Data.Entity;

namespace DoE.Lsm.ShoppingCard.Api
{
    using API;
    using Data.Repositories;
    using Data.Repositories.EF;
    using Norms.Validations;

    ///<summary>
    /// Creates an API class that will handle all the actions actioned on 
    ///</summary>
    public class Card : ICardRepository
    {

        private decimal price = 0.00M;
        private readonly string bookYear;

        private readonly IRepositoryStoreRegistry _databaseContextRepository;
        private readonly DbContext     _dbContext;     
        private readonly NormVettingInstance qtVettingInstance = new NormVettingInstance();

        public Card(IRepositoryStoreRegistry databaseContextRepository, DbContext dbContext)
        {
            this._databaseContextRepository = databaseContextRepository;
            this.bookYear                   = databaseContextRepository.StandardsAndNorms.BookYear;
            this._dbContext                 = dbContext;
        }


        ///<summary>
        ///  This method will add a new Item to a card. This needs a dynamic context to allow different types of items to be ordered.
        ///  <remark>This needs a dynamic context to allow different types of items to be ordered. </remark>
        ///  <para name="rqInstance"> Requisitions Instance Id </param>
        ///  <para name="id">                                  </param>
        ///  <para name="qty"> Requested Quantity              </param>
        ///  <para name="school"> School requesting            </param>
        ///  <para name="minGrade">Minimum Grade               </param>
        ///  <para name="maxGrade">Maximum Grade               </param>
        ///</summary>
        public async Task<int> AddToCard(Guid rqInstance, string reqNo,  int id, int qty, School school, byte minGrade, byte maxGrade, string stage, string state)
        {
            using(var transaction = _dbContext.Database.BeginTransaction())
            {

            try
            {
                var item      = await _databaseContextRepository.InventoryStore.SingleAsync(id); //grabs an item from the inventory 
                var bookPrice = item.Price;
                int quota     = item.Quota ?? 0;   

                var hasPassedQuotaVetting = qtVettingInstance.HasPassed(qty, ref quota, item.CategoryCD, item.Teacher_Enr);  //conducts quota vetting.

                switch (hasPassedQuotaVetting)
                {

                    case Policy.Passed:
                    checked
                    { price = (item.Price * (decimal)qty);  } //avoids arithmetics overflows.Rollsback transaction when this exception is caught.

                    string rqNo         = await _databaseContextRepository.Requisitions.MergeOnAsync(rqInstance, reqNo, school, minGrade, maxGrade, bookYear, stage, state);

                    var updateInventory = await _databaseContextRepository.InventoryStore.UpdateAsync(item, qty);

                    var execr            = await _databaseContextRepository.InventoryStore.SaveListItemAsync(rqInstance.ToString(), 
                                                                                                             item.RowGuid.ToString(), 
                                                                                                             new InventoryRequest
                                                                                                             {
                                                                                                                 CategoryCD         = item.CategoryCD,
                                                                                                                 CreationDate       = DateTime.Now,
                                                                                                                 EntityId           = school.RowGuid.ToString(),
                                                                                                                 LastModifiedDate   = DateTime.Now,
                                                                                                                 Price = bookPrice
                                                                                                             });
                     transaction.Commit();
                    return (int)execr;
                    case Policy.Failed:
                        return -1;
                    default:
                        return -1;
                }

            }
            catch
            {
                    transaction.Rollback();
                return -1;
                    }
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="reqId"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public IEnumerable<vw_ShoppingCardItems> ItemList(string reqId, int id)
        {
//            return _databaseContextRepository.RequisitionOrderItems.GetRequisitionOrderOItems(reqId, id, bookYear);
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entityType"></param>
        /// <param name="entityId"></param>
        /// <param name="itemId"></param>
        public void RemoveItem( string entityType, string entityId, string itemId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entityId"></param>
        /// <param name="sender"></param>
        /// <param name="receiver"></param>
        /// <returns></returns>
        public async Task<int> CheckOut(string entityId, int sender, int receiver)
        {


            //var requisition = await _databaseContextRepository.Requisitions.GetRequisitionByReqNoAsync(reqId);

            //var task = new WF.Jobs.Task
            //{
            //    Receiver = receiver,
            //    Sender = sender,
            //    Action = WF.Jobs.Task.Activity.Submit
            //};

            ////            int wfTask = await Principal.ProcessRequestAsync<Education.Repository.EF.Requisition>(requisition, task);

            ////          return wfTask;
            //return 1;

            var testToken = 0;

            await Task.FromResult(testToken);

            throw new NotImplementedException();

        }

        /// <summary>
        ///  <remark>
        ///  Use global namespace aliases to handles entity type name conflicts
        ///    <example>
        ///   <code>
        ///     using EF = DoE.Data.Repository.EF; 
        /// 
        ///     identifier.GetTotalPrice<EF::Requisitions>("dummyData.EntityType.Value", "dummyData.EntityId.Value", 4578) 
        ///   </code>
        ///  </example>
        /// </remark>   
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entityType"></param>
        /// <param name="entityId"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public decimal GetTotalPrice<T>(string entityType, string entityId, int id) where T : class
        {
            return 0.00M;
        }
    }
}