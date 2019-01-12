
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DoE.Models.CircuitRequisitions
{

    #region -->  Index Page Properties

    public partial class CircuitManagerRequisitionsViewModel
    {
        //public IEnumerable<vwRequistionTicket> RequisitionWorkFlowTickets { get; set; }

        public int TotalSchoolsPerCircuits { get; set; }

        //public AspNetProfile CircuitManager { get; set; }

        public int IndependentSchools { get; set; }

        public double IndependentSchoolsFigures { get; set; }

        public int PublicSchools { get; set; }

        public double PublicSchoolsFigures { get; set; }

        public int Term { get; set; }

        public string BookYear { get; set; }

        public string DataYear { get; set; }

        public int SchoolsPerQuintile { get; set; }

        public double WarehouseUploadsPerQuintile { get; set; }

        public int WarehouseUploadsPerCircuit { get; set; }

    }
    #endregion

    #region --> Properties for Child Actions
    public partial class CircuitManagerRequisitionsViewModel
    {
        //public IEnumerable<EnrolmentPerClassPerSubject> EnrolmentPerGradePerSubject { get; set; }

        public IEnumerable<int> Grades { get; set; }

        public int EmisCode { get; set; }
    }
    #endregion

    public class CMRequisitionsViewModel
    {
        //public IList<vwst_ltsmWarehouseImports> WarehouseImports { get; set; }

        //public IList<vwst_lsmOutstandingWarehouseUploads> OutstandingUploads { get; set; }
    }


    #region --> Inbox View Model :: Handles openning of requisitions and denying or accepting them.

    public partial class InboxViewModel
    {

        //public School School { get; set; }

        //public Requisition Requisition { get; set; }

        //public WorkFlow WorkFlowTicket { get; set; }

        //public IEnumerable<req_vwOrderItems> RequisitionOrderItems { get; set; }

        public decimal TotalPrice { get; set; }

        //public IEnumerable<WorkFlowTimeLine> WorkFlowTimeLine { get; set; }

    }


    public partial class InboxViewModel
    {
        [Required(ErrorMessage ="Please enter your reason in the text box in order to have this requisition to be declared declined.")]
        public string Message { get; set; }

        [Required]
        public string RequisitionId { get; set; }
    }

    #endregion


}