using System;

namespace DoE.Lsm.Data.Repositories
{
    using EF;
    using UI;
    using Lock;
    using Logger;
    using Persons;
    using Workflow.Engine;

    public class RepositoryStoreManager : IRepositoryStoreManager
   {

        private readonly ILogger _logger;

        private readonly PortalLsm     _productionDbContext;
        private readonly PortalAuth    _authenticationDbContext;
        private readonly PortalSnE     _applicationSnEDbContext;

        public RepositoryStoreManager(ILogger logger)
        {
                        this._logger = logger;

                        _productionDbContext     = new PortalLsm();
                        _authenticationDbContext = new PortalAuth();
                        _applicationSnEDbContext = new PortalSnE();

                        IdentityManager = new IdentityAuthRepository(_authenticationDbContext, logger);
                        Processes = new ProcessManagerRepository(_applicationSnEDbContext, logger);

                        Locker = new LockerRepository(_productionDbContext, logger);
                        Requisitions = new RequisitionRepository(_productionDbContext, logger);
        }

        public ProcessManagerRepository Processes
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
                _productionDbContext.Dispose();
            }
        }
        #endregion
    }
}