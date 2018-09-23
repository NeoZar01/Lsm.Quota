namespace DoE.Lsm.Data.Repositories
{
    using System;
    using UI;
    using Norms;
    using Persons;
    using Workflow.Engine;
    using Repository.Inventories;
    using Subcity;
    using Orders;
    using Profile;
    using Lock;

    public interface IRepositoryStoreRegistry : IDisposable
    {

        ///<summary>
        ///      Create a reference store to the workflow namespace
        ///</summary>
        ProcessManagerRepository WFProcessStore
        { get; set; }

        ///<summary>
        ///      Handles inventory queries
        ///</summary>
        InventoryRepository InventoryStore
        { get; set; }

        ///<summary>
        ///     Handles scales and norms queries.
        ///   <remark> This should be a read-only class</remark>
        ///</summary>
        NormsStandardsRepository StandardsAndNorms
        { get; set; }

        #region ProfileStore
        ///<summary>
        ///    Handles profile related queries.
        ///    The <c>ASPNETProfile entity should no longer be used since we split it into </c>
        ///    <see> <c>IPrinciple</c> class and how we can extend its methods to add more custom queries.All methods in this class should be moved to this customization. </see>
        ///</summary>
        [Obsolete]
        ProfileRepository ProfileStore
        { get; set; }

        PersonRepository Person
        { get; set; }

        RequisitionRepository Requisitions
        { get; set; }

        #endregion

        OrderRepository Orders
        { get; set; }

        RequisitionSubcityRepository Subcity
        { get; set; }

        UIManagerRepository UI
        { get; set; }

        LockerRepository Locker
        { get; set; }
    }
}
