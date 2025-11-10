
using System.ComponentModel.DataAnnotations;
namespace LoanManagement.Model
{
    public class PassLoanInfo
    {
        [Key]
        public string LoanId { get; set; }
        public string UserEmail { get; set; }
        public string? LoanType { get; set; }
        public float? LoanAmount { get; set; }
        public float InterestRate { get; set; }
        public float InterestAmount { get; set; }
        public float ProcessingFee { get; set; }
        public int LoanDurationInMonths { get; set; }
        public string LoanDate { get; set; }
        public string LoanTime { get; set; }
        public string? LoanPayDate { get; set; }
        public float? LoanAmountLeft { get; set; }
    }
}
