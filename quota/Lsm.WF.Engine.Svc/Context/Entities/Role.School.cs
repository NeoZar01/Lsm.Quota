namespace DoE.Lsm.WF.Engine.Context.Entities
{
    using Data.Repositories;

    public class School : Role
    {
        public School(IRepositoryStoreRegistry DbRepository) : base(DbRepository){}

    }
}
