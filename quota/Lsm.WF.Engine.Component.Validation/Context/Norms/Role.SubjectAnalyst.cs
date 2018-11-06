namespace DoE.Lsm.WF.WI.Context.Norms
{
    using Data.Repositories;
    using Logger;

    public class SubjectAnalystHandler :  Role
    {         
        public SubjectAnalystHandler(ILogger logger, IRepositoryStoreManager DbContext) : base(logger, DbContext) {}            
    }
}
