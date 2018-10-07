namespace DoE.Lsm.WF.Engine.Context.Entities
{
    using Data.Repositories;

    public class SubjectAnalyst :  Role
    {         
        public SubjectAnalyst(IRepositoryStoreRegistry DbContext) : base(DbContext) {}            
    }
}
