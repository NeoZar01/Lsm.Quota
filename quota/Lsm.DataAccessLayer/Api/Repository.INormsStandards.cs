using System;
using System.Collections.Generic;

namespace DoE.Lsm.Data.Repository.Norms
{
    using Annotations;
    using Repositories;
    using Repositories.EF;

    public interface INormsStandardsRepository : IRepository<vw_RequisitionsNorms>
   {

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="emisId"></param>
        ///// <param name="bookYear"></param>
        ///// <returns></returns>
        //IEnumerable<vw_RequisitionsNorms> GetNorms([Column(BookYear = Column.Fact.IsRequired)] Guid emisId, string bookYear);

        /// <summary>
        /// 
        /// </summary>
        string BookYear { get; }

        ///// <summary>
        ///// 
        ///// </summary>
        //int AccountingTerm { get; }

        ///// <summary>
        ///// 
        ///// </summary>
        //string AccountingYear { get; }
    }
}