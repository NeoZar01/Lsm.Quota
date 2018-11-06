namespace DoE.Lsm.WF.Engine.Context.Entities
{
    using Data.Repositories;
    using Logger;

    public class CircuitManager :  Role
    {
      public CircuitManager(ILogger logger, IRepositoryStoreManager DbContext) : base(logger, DbContext) {}
    }
}