namespace DoE.Lsm.ShoppingCard.Api
{
    using DoE.Lsm.Data.Repositories;

    public class ShoppingCard  : IShoppingCard
    {

        public ShoppingCard(IRepositoryStoreRegistry dataStore)
        {
            CardRepository = new Card(dataStore, dataStore.Requisitions.DbContext);
        }

        public Card CardRepository
        { get; set; }

    }
}
