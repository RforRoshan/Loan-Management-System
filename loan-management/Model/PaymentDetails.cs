using System.ComponentModel.DataAnnotations;

namespace LoanManagement.Model
{
    public class PaymentDetails
    {
        [Key]
        public string OrderId { get; set; }
        public string LoanId { get; set; }
        public string UserEmail { get; set; }
        public string Name { get; set; }
        public string? LoanType { get; set; }
        public float PayedAmount { get; set; }
        public float AmountLeft { get; set; }
        public string PaymentDate { get; set; }
        public string PaymentTime { get; set; }
    }
}
