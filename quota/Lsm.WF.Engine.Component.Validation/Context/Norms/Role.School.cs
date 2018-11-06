namespace DoE.Lsm.WF.WI.Context.Norms
{
    using Data.Repositories;
    using Logger;

    public class SchoolHandler : Role
    {
        public SchoolHandler(ILogger logger, IRepositoryStoreManager DbRepository) : base(logger, DbRepository) {}
    }
}
