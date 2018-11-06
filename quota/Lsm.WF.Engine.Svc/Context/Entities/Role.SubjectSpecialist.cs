namespace DoE.Lsm.WF.Engine.Context.Entities
{
    using Data.Repositories;
    using Logger;

    public class SubjectAnalyst :  Role
    {         
        public SubjectAnalyst(ILogger logger, IRepositoryStoreManager DbContext) : base(logger, DbContext) {}            
    }
}
