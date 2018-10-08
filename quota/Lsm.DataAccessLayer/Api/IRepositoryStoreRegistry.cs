using System;

namespace DoE.Lsm.Data.Repositories
{
    using UI;
    using Lock;
    using Persons;
    using Workflow.Engine;


    public interface IRepositoryStoreRegistry : IDisposable
    {

        ///<summary>
        ///      Create a reference store to the workflow namespace
        ///</summary>
        ProcessManagerRepository WFProcessStore
        { get; set; }

        #region ProfileStore
        ///<summary>
        ///    Handles profile related queries.
        ///    The <c>ASPNETProfile entity should no longer be used since we split it into </c>
        ///    <see> <c>IPrinciple</c> class and how we can extend its methods to add more custom queries.All methods in this class should be moved to this customization. </see>
        ///</summary>

        PersonRepository Person
        { get; set; }

        #endregion

        /// <summary>
        /// 
        /// </summary>
        UIManagerRepository UI
        { get; set; }

        /// <summary>
        /// 
        /// </summary>
        LockerRepository Locker
        { get; set; }


        /// <summary>
        /// 
        /// </summary>
        RequisitionRepository Requisitions
        { get; set; }


    }
}
