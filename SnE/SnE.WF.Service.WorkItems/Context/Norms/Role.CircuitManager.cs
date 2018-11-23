namespace DoE.Lsm.WF.WI.Context.Norms
{
    using Data.Repositories;
    using Logger;

    public class CircuitHandler :  Role
    {
      public CircuitHandler(ILogger logger, IRepositoryStoreManager DbContext) : base(logger, DbContext) {}
    }
}