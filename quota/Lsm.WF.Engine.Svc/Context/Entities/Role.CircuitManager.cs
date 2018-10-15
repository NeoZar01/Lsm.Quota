namespace DoE.Lsm.WF.Engine.Context.Entities
{
    using Data.Repositories;

    public class CircuitManager :  Role
    {
        public CircuitManager(IRepositoryStoreManager DbContext) : base(DbContext) {}

    }
}