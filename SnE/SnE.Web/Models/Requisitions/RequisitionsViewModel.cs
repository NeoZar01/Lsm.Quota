using System.Collections.Generic;
using PagedList;
using System.ComponentModel.DataAnnotations;

namespace DoE.Models
{


    /**
     *     public class WFEngine : IWFEngine
    {

        public readonly IRepositoryStore _DbRepository;

        public WFEngine(IRepositoryStore DbRepository)
        {
                this._DbRepository = DbRepository;

                WF = new ManagementTree().Roles(DbRepository);
        }

        public ManagementTree WF { get; set; }
    }
     * 
     * **/
    //--> Neo - > Nov, 2016
    /*
         --->   Home page pools this properties by default    
     */
    public partial class RequisitionHomeViewModel
    {

        public string BookYear { get; set; }
        //public IEnumerable<vws_ReqAccountingDates> AccountingDateForBookYear { get; set; }
        public decimal RequistionTotalPricePerBookYear { get; set; }
        //public IEnumerable<vwRequistionTicket> WFRequisitions { get; set; }
        public int TotalNumberOfRequisitions { get; set; }
    }


    //#  Handles partial View      
    public partial class RequisitionHomeViewModel
    {
                public IEnumerable<int> RequisitionOrdersPerGrade { get; set; }
                //public IEnumerable<Metric> OrderPerGradeDashboard { get; set; }
                //public IPagedList<vw_RequisitionOrderItems> CatalogueResultSet { get; set; }
                public IEnumerable<string> GetFilterableSubjectsPerKeySearch { get; set; }
    }

//#  Redirectes after a triggered event
    public partial class RequisitionHomeViewModel
    {
        //public IEnumerable<vw_EduCataloguePerSchool> BooksSharingSimilarAttributes { get; set; }
        //public vw_EduCataloguePerSchool Item { get; set; }
    }

    public partial class RequisitionsViewModel
    {

     //clean models 
        public string BookYear { get; set; }
        public string requisitionId { get; set; }
        public string Status { get; set; }
        //public AspNetProfile Incumbent { get; set; }

        //public IEnumerable<vw_ShoppingCardItems> ShoppingCardList { get; set; }
        //public Requisition Requisition { get; set; }

        //public School School { get; set; }

        public decimal TotalPrice { get; set; }

        //public IPagedList<vw_RequisitionOrderItems> GetOrderedItems { get; set; }

        //public IEnumerable<WorkFlowTimeLine> RWFTimeline { get; set; }

        //public IEnumerable<WorkFlowTicketMessage> RWFMessages { get; set; }

        public decimal ConfirmedRequisitionsSubcity { get; set; }

        //public vwTotalSubcityPerCircuit SubcityCostsPerCircuit { get; set; }

        public double OrdersPerCircuitPerSchoolContribution { get; set; }

    }

    //For child action
    public partial class RequisitionsViewModel
    {
        //public IPagedList<vw_RequisitionOrderItems> GetBookmarks { get; set; }
    }

    //For HttpPost Actions
    public partial class RequisitionsViewModel
    {
        [Required]
        public int Quantity { get; set; }

        [Required]
        public int ItemId { get; set; }
    }

    //Error Handlers
    public partial class RequisitionsViewModel 
    {
        public int IsError { get; set; }
        public string ErrorMessage { get; set; }
    }

    #region  --> Mini dashboard
    public partial class RequisitionsViewModel
    {
        public int TotalNumberOfRequisitions { get; set; }
        public int SchoolsPerCircuitTotal { get; set; }
    }
    #endregion

    public partial class ShoppingCardViewModel
    {

        //public School School { get; set; }

        //public AspNetProfile Approver { get; set; }

        //public IEnumerable<vw_ShoppingCardItems> ShoppingCardList { get; set; }

        //public SchoolAddress Address { get; set; }

    }

    /*     
     *   --> wraps models for shopping card
     */

    public partial class ShoppingCardViewModel
    {

//        public IList<vwclsb_FullyQualifyableOrderCatalogue> searchCatalogueViewObject { get; set; }

        [Required]
        public string reqId { get; set; }

        [Required]
        public string BookY { get; set; }

        [Required]
        public int GrFrm { get; set; }

        [Required]
        public int GrTo { get; set; }

        [Required]
        public string Status { get; set; }

        [Required]
        public decimal TotalPrice { get; set; }

    }   

}