using System.Linq;
using DoE.Lsm.Logger;
using DoE.Lsm.Data.Repositories.EF;
using DoE.Lsm.Data.Repository.Norms;

namespace DoE.Lsm.Data.Repositories.Norms
{

    public class NormsStandardsRepository : Repository<vw_RequisitionsNorms>, INormsStandardsRepository
    {

        public NormsStandardsRepository(PortalLsm dbContext, ILogger logger) : base(dbContext, logger) {}

        //public IEnumerable<vw_RequisitionsNorms> GetNorms(int EmisCode, string bookyear)
        //{
        //    try
        //    {
        //        return LsmEntityDB.vw_RequisitionsNorms
        //                 .Where(c => c.EmisCode == EmisCode)
        //                 .Where(c => c.BookYear.Equals(bookyear));
        //    }
        //    catch (Exception e)
        //    {
        //        throw new EntityNotFoundException( e.InnerException.ToString(), "Unable To Load Calendar", "Ensure that calendar configurations for this year is active." , LsmEntityDB.vw_RequisitionsNorms, 0, true, Severity.High.Yes);
        //    }
        //}

        private PortalLsm DataSource { get { return this._DbContext as PortalLsm; } }


        public string BookYear
        {
            get
            {
                try
                {
                    var bookYear =
                                DataSource.vw_RequisitionsNorms
                                          .Select(c => c.BookYear)
                                          .Single();
                    return bookYear;
                }
                catch
                {
                    throw; //  throw new InstanceNotFoundException(e.InnerException.ToString(), "Unable To Load Book Year ", "Ensure that Book Year configurations for this calendar is active.", LsmEntityDB.vw_RequisitionsNorms, 0, true, Severity.High.Yes);
                }
            }
        }

        //[DataMember]
        //public int AccountingTerm
        //{
        //    get
        //    {
        //        try
        //        {

        //            var calendar = LsmEntityDB.vw_RequisitionsNorms
        //                          .Take(1)
        //                          .Select(c => c.Term)
        //                          .Single();
        //            return calendar;
        //        }
        //        catch (Exception e)
        //        {
        //            throw new EntityNotFoundException(e.InnerException.ToString(), "Unable To Load Term", "Ensure that the term configurations are active.", LsmEntityDB.vw_RequisitionsNorms, 0, true, Severity.High.Yes);
        //        }
        //    }
        //}

        //[DataMember]
        //public string AccountingYear
        //{
        //    get
        //    {
        //        try
        //        {

        //            var calendar = LsmEntityDB.vw_RequisitionsNorms
        //                          .Take(1)
        //                          .Select(c => c.Year)
        //                          .Single();
        //            return calendar.ToString();
        //        }
        //        catch (Exception e)
        //        {
        //            throw new EntityNotFoundException(e.InnerException.ToString(), "Unable To Load Calendar", "Ensure calendar for this book year is active.", LsmEntityDB.vw_RequisitionsNorms, 0, true, Severity.High.Yes);
        //        }
        //    }
        //}
    }
}