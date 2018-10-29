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

    public class RepositoryStoreManager : IRepositoryStoreManager
   {

        private readonly ILogger _logger;

        private readonly PortalLsm     _ProductionDbContext;
        private readonly PortalAuth    _authenticationDbContext;
        private readonly PortalSnE     _applicationSnEDbContext;

        public RepositoryStoreManager(ILogger logger)
        {
                        this._logger = logger;

                        _ProductionDbContext     = new PortalLsm();
                        _authenticationDbContext = new PortalAuth();
                        _applicationSnEDbContext = new PortalSnE();

                        IdentityManager = new IdentityAuthRepository(_authenticationDbContext, logger);
                        WI = new ProcessManagerRepository(_applicationSnEDbContext, logger);

                        Locker = new LockerRepository(_ProductionDbContext, logger);
                        Requisitions = new RequisitionRepository(_ProductionDbContext, logger);
        }

        public ProcessManagerRepository WI
        { get; set; }

        public IdentityAuthRepository IdentityManager
        { get; set; }

        public UIManagerRepository UI
        { set; get; }

        public LockerRepository Locker
        { get; set; }

        public RequisitionRepository Requisitions
        { get; set; }

        #region GC
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