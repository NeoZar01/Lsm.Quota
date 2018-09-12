using System;

namespace DoE.Lsm.WF.Engine.Context.Entities
{
    using Data.Repositories;

    [Obsolete("I am not sure why I am using this class for.Before it was meant to view all the workflow instances to circuit managers")]
    public class Tickets
    {
        private readonly IRepositoryStore DbContext;

        public Tickets(IRepositoryStore DbContext)
        {this.DbContext = DbContext;}
    }
}
