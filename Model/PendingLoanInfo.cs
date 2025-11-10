

using System.ComponentModel.DataAnnotations;

namespace LoanManagement.Model
{
    public class PendingLoanInfo
    {
        [Key]
        public string LoanId { get; set; }
        public string UserEmail { get; set; }     
        public string? LoanType { get; set; }
        public float? LoanAmount { get; set; }
        public string LoanDate { get; set; }
        public string LoanTime { get; set; }
        public int? LoanDurationInMonths { get; set; }
        public bool LoanNotPass { get; set; }
        public string? LoanNotPassReason { get; set; }
    }
}
