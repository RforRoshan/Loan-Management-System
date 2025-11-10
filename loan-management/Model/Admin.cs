using System.ComponentModel.DataAnnotations;

namespace LoanManagement.Model
{
    public class Admin
    {
        [Key]
        public string Email { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
    }
}
