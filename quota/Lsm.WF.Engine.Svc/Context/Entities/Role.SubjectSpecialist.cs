namespace DoE.Lsm.WF.Engine.Context.Entities
{
    using Data.Repositories;

    public class SubjectAnalyst :  Role
    {         
        public SubjectAnalyst(IRepositoryStoreManager DbContext) : base(DbContext) {}            
    }
}
