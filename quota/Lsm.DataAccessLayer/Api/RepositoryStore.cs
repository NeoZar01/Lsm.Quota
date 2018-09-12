using System;

namespace DoE.Lsm.Data.Repositories
{
    using Logger;
    using UI;
    using Persons;
    using EF;
    using Norms;
    using Repository.Inventories;
    using Orders;
    using Workflow.Engine;
    using Subcity;
    using Profile;

    public class RepositoryStore : IRepositoryStore
   {

        private readonly PortalLsm     _LsmDbContext;
        private readonly PortalAuth    AuthDbContext;
        private readonly ILogger _logger;
        public RepositoryStore(ILogger logger)
        {
                        this._logger = logger;

                        _LsmDbContext = new PortalLsm();
                        AuthDbContext = new PortalAuth();

                        WFProcessStore         = new ProcessManagerRepository(_LsmDbContext, logger);
                        InventoryStore          = new InventoryRepository(_LsmDbContext, logger);
                        Scales                  = new NormsStandardsRepository(_LsmDbContext, logger);
                        Requisitions            = new RequisitionRepository(_LsmDbContext, logger);
                        Orders                  = new OrderRepository(_LsmDbContext, logger);
                        RequisitionItem         = new InventoryRepository(_LsmDbContext, logger);
                        Subcity                 = new RequisitionSubcityRepository(_LsmDbContext, logger);
                        ProfileStore            = new ProfileRepository(AuthDbContext, logger);
                        Person                  = new PersonRepository(AuthDbContext, logger);
                        RequisitionOrderItems   = new RequisitionOrderItemsRepository(_LsmDbContext, logger);
        }

                public InventoryRepository      InventoryStore
                { get; set; }

                public NormsStandardsRepository          Scales
                { get; set; }

                public ProfileRepository        ProfileStore
                { get; set; }

                public RequisitionRepository    Requisitions
                { get; set; }

                public OrderRepository          Orders
                { get; set; }

                public InventoryRepository RequisitionItem
                { get; set; }

                public RequisitionOrderItemsRepository RequisitionOrderItems
                { get; set; }

                public ProcessManagerRepository WFProcessStore
                { get; set; }

                public PersonRepository Person
                { get; set; }

                public RequisitionSubcityRepository Subcity
                { get; set; }

                public UIManagerRepository UI
                { set; get; }


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
                _LsmDbContext.Dispose();
            }
        }
        #endregion
    }
    }
