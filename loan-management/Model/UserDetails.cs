using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace LoanManagement.Model
{
    public class UserDetails
    {

        [Key]
        public string Email { get; set; }
        public string? Aadhaar { get; set; }
        public string? UserImagePath { get; set; }
        public string? Fname { get; set; }
        public string? Mname { get; set; }
        
        public string? Sname { get; set; }

        
        [DataType(DataType.Date)]
        public string? DOB { get; set; }
        
        public string? Gender { get; set; }
        
        public string? MobileNo { get; set; }
        
        public string? MaritalStatus { get; set; }
        
        public string? PanNo { get; set; }
        
        public string? Address { get; set; }
        
        public string? State { get; set; }
        
        public string? City { get; set; }
        
        public string? District { get; set; }
        
        public string? PinCode { get; set; }
        
        public string? BankAccountNo { get; set; }
        
        public string? BankIFSCCode { get; set; }

        public string? AadharCardImagePath { get; set; }
        public string? PANCardImagePath { get; set; }
    }
}
