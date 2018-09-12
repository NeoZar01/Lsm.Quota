namespace DoE.Lsm.Data.Repositories  {

    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using WF.Engine.Context;
    using Annotations;
    using EF;

    public interface IRequisitionsRepository : IRepository<Requisition>
    {
        /// <summary>
        /// 
        /// </summary>
        string LastInMemoryRequisition { get; set; }

        /// <summary>
        /// 
        /// </summary>
        string State { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="stage"></param>
        /// <param name="state"></param>
        /// <returns></returns>
        ExecutionResult Park(Requisition e, string stage, string state);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="stage"></param>
        /// <param name="state"></param>
        /// <returns></returns>
        Task<ExecutionResult> ParkAsync(Requisition e, string stage, string state);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entityId"></param>
        /// <returns></returns>        
        bool Exists([InstanceEntityType("REQUISITION")]Guid entityId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entityId"></param>
        /// <returns></returns>
        Task<bool> ExistsAsync([InstanceEntityType("REQUISITION")]Guid entityId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entityId"></param>
        /// <returns></returns>
        Requisition FindByInstanceId([InstanceEntityType("REQUISITION")]Guid entityId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="requisitionNo"></param>
        /// <returns></returns>
        Task<Requisition> GetRequisitionByEntityIdAsync([InstanceEntityType("REQUISITION")]Guid requisitionNo);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="emisEntityId"></param>
        /// <param name="calendar"></param>
        /// <returns></returns>
        int RequisitionsPerCalendar([Column(Calendar = Column.Fact.IsRequired)] string emisEntityId, string calendar);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="emisId"></param>
        /// <param name="calendar"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        decimal TotalPricePerCalendar([Column(Calendar = Column.Fact.IsRequired)] string emisId, string calendar, string status);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entityId"></param>
        /// <param name="reqNo"></param>
        /// <param name="s"></param>
        /// <param name="minGrade"></param>
        /// <param name="maxGrade"></param>
        /// <param name="calendar"></param>
        /// <param name="stage"></param>
        /// <param name="state"></param>
        /// <returns></returns>
        Task<string> MergeOnAsync([InstanceEntityType("REQUISITION")]Guid entityId, string reqNo, School s, byte minGrade, byte maxGrade, string calendar, string stage, string state);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="emisCode"></param>
        /// <param name="stage"></param>
        /// <param name="state"></param>
        /// <returns></returns>
        IEnumerable<Requisition> GetRequisitionsByState(string emisCode, string stage , string state);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="reqNo"></param>
        /// <param name="emisId"></param>
        /// <returns></returns>
        Task<bool> IsInstanceReadWriteAsync(string reqNo, string emisId);
    }
}
