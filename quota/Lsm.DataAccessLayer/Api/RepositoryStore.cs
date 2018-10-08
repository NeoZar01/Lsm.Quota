using System;

namespace DoE.Lsm.Data.Repositories
{
    using Logger;
    using UI;
    using Persons;
    using EF;
    using Workflow.Engine;
    using Profile;
    using Lock;

    public class RepositoryStore : IRepositoryStoreRegistry
   {
        /// <summary>
        /// 
        /// </summary>
        private readonly ILogger _logger;

        /// <summary>
        /// 
        /// </summary>
        private readonly PortalLsm     _ProductionDbContext;
    
        /// <summary>
        /// 
        /// </summary>
        private readonly PortalAuth    _authenticationDbContext;
        
        public RepositoryStore(ILogger logger)
        {
                        this._logger = logger;

                        _ProductionDbContext     = new PortalLsm();
                        _authenticationDbContext = new PortalAuth();

                        WFProcessStore = new ProcessManagerRepository(_ProductionDbContext, logger);
                        Person = new PersonRepository(_authenticationDbContext, logger);
                        Locker = new LockerRepository(_ProductionDbContext, logger);
                        Requisitions = new RequisitionRepository(_ProductionDbContext, logger);
        }

                public ProcessManagerRepository WFProcessStore
                { get; set; }

                public PersonRepository Person
                { get; set; }

                public UIManagerRepository UI
                { set; get; }


                public LockerRepository Locker
                { get; set; }

                public RequisitionRepository Requisitions
                { get; set; }

        #region Gabbage Collection
        private bool _disposed = false;
        private static readonly object _syncLock = new object();

        public void Dispose()
        {
            Dispose(true);

            GC.SuppressFinalize(this);
        }
        public void Dispose(bool disposing)
        {
            if (_disposed) return;

            if (disposing)
            {
                _ProductionDbContext.Dispose();
            }
        }
        #endregion
    }
    }
