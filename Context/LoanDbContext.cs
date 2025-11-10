using LoanManagement.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace LoanManagement.Context
{
    public class LoanDbContext:DbContext
    {
            public LoanDbContext(DbContextOptions<LoanDbContext> Context) : base(Context)
            {

            }
        public DbSet<LoanType> LoanTypes { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserDetails> UsersDetails { get; set; }
        public DbSet<PendingLoanInfo> PendingLoansInfoTable { get; set; }
        public DbSet<PassLoanInfo> PassedLoansInfoTable { get; set; }
        public DbSet<PaymentDetails> PaymentsDetailsTable { get; set; }
        public DbSet<Admin> AdminsTable { get; set; }
    }
}
