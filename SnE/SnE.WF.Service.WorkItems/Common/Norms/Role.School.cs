namespace DoE.Lsm.WF.WI.Context.Norms
{
    using Data.Repositories;
    using Logger;

    public class School : Role
    {
        public School(ILogger logger, IRepositoryStoreManager DbRepository) : base(logger, DbRepository) {}
    }
}
