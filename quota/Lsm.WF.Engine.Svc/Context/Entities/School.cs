namespace DoE.Lsm.WF.Engine.Context.Entities
{
    using Data.Repositories;

    public class School : Role
    {
        public School(IRepositoryStore DbRepository) : base(DbRepository){}

    }
}
