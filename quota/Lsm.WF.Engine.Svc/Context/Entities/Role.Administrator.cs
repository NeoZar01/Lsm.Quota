namespace DoE.Lsm.WF.Engine.Context.Entities
{
    using Data.Repositories;
    using Logger;
    using WI.Context.Entities;

    public class Administrator : Role
   {
        public Administrator(ILogger logger, IRepositoryStoreManager dataStore) : base(logger, dataStore)
        {}
    }
}