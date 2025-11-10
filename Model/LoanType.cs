using System.ComponentModel.DataAnnotations;

namespace LoanManagement.Model
{
    public class LoanType
    {
        [Key]
        public string LoanName { get; set; }
        public string LoanImagepath { get; set; }
        public string LoanDescription { get; set; }
    }
}
