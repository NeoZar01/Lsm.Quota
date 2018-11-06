namespace DoE.Lsm.WF.Engine.Context.Entities
{
    using Data.Repositories;
    using Logger;

    public class School : Role
    {
        public School(ILogger logger, IRepositoryStoreManager DbRepository) : base(logger, DbRepository) {}
    }
}
