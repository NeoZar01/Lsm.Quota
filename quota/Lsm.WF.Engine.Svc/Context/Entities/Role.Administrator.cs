namespace DoE.Lsm.WF.Engine.Context.Entities
{
    using Data.Repositories;

    public class Administrator : Role
   {
        public Administrator(IRepositoryStoreManager dataStore) : base(dataStore)
        {}
    }
}