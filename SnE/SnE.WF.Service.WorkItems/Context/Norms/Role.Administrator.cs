namespace DoE.Lsm.WF.WI.Context.Norms
{
    using Data.Repositories;
    using Logger;

    public class Administrator : Role
   {
        public Administrator(ILogger logger, IRepositoryStoreManager dataStore) : base(logger, dataStore)
        {}
    }
}