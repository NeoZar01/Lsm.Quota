using System;
using System.Data.Entity;
using DoE.Lsm.Data.Repositories.EF;
using DoE.Lsm.Data.Repositories;
using DoE.Lsm.Logger;

namespace DoE.Lsm.Data.Repositories.Subcity
{

    public class RequisitionSubcityRepository : RepositoryFactory<vw_RequisitionsDashboard>, IRequisitionSubcityRepository
    {

        public RequisitionSubcityRepository(DbContext context, ILogger logger) : base(context, logger){}


        //public decimal ConfirmationDeniedRequisitionsSubcityPrice(int emisCode, string bookYear)
        //{
        //    try
        //    {
        //        var query = LsmDBContext.vw_RequisitionsDashboard
        //            .Where(c => c.BookYear.Equals(bookYear) && c.EmisCode == emisCode)
        //            .SingleOrDefault();
        //        return query.TotalP_Reject ?? 0.0M;
        //    }
        //    catch
        //    {
        //        return 0.0M;
        //    }
        //}

        //public decimal ConfirmedRequisitionsSubcityPrice(int emisCode, string bookYear)
        //{
        //    try
        //    {
        //        var query = LsmDBContext.vw_RequisitionsDashboard
        //            .Where(c => c.BookYear.Equals(bookYear) && c.EmisCode == emisCode)
        //            .SingleOrDefault();

        //        return query.TotalP_Approved ?? 0.0M;
        //    }
        //    catch
        //    {
        //        return 0.0M;
        //    }
        //}

        //public decimal DraftedRequisitionsSubcityPrice(int emisCode, string bookYear)
        //{
        //    try
        //    {
        //        var query = LsmDBContext.vw_RequisitionsDashboard
        //            .Where(c => c.BookYear.Equals(bookYear) && c.EmisCode == emisCode)
        //            .SingleOrDefault();

        //        return query.InDrafts ?? 0.0M;
        //    }
        //    catch
        //    {
        //        return 0.0M;
        //    }
        //}

        //public decimal SubmittedRequisitionsSubcityPrice(int emisCode, string bookYear)
        //{
        //    try
        //    {
        //        var query = LsmDBContext.vw_RequisitionsDashboard
        //            .Where(c => c.BookYear.Equals(bookYear) && c.EmisCode == emisCode)
        //            .SingleOrDefault();

        //        return query.Sub_TotalPrice ?? 0.0M;
        //    }
        //    catch
        //    {
        //        return 0.0M;
        //    }
        //}

        //public vwTotalSubcityPerCircuit SubcityPerCircuit(int circuitCD)
        //{
        //    try
        //    {
        //        var subcityPerCircuitQuery  = LsmDBContext.vwTotalSubcityPerCircuits
        //            .Where(c => c.CircuitCD == circuitCD)
        //            .SingleOrDefault();
        //        return subcityPerCircuitQuery;                    
        //    }
        //    catch(Exception e)
        //    {
        //        throw new EntityNotFoundException(e.InnerException.ToString(), "Unable To Find Subcity Per Circuit Message", "Ensure that the right configurations are made for this circuit and that schools has created requisitions that were accepted by the circuit manager.", LsmDBContext.vwTotalSubcityPerCircuits, circuitCD, true , Severity.High.No);
        //    }
        //}

        public PortalLsm LsmDBContext { get { return this._DbContext as PortalLsm; } }
    }
}
