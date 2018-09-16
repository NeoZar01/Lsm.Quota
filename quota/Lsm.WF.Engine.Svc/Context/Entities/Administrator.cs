namespace DoE.Lsm.WF.Engine.Context.Entities
{
    using Data.Repositories;

    public class Administrator : Role
   {
        public Administrator(IRepositoryStoreRegistry dataStore) : base(dataStore)
        {}
    }
}