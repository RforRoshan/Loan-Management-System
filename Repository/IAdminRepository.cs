using LoanManagement.Model;

namespace LoanManagement.Repository
{
    public interface IAdminRepository
    {
        void ApproveLoan(AdminApproveLoanData adminApproveLoanData);
        Admin GetAdminDetails(EmailAndPass emailAndPass);
        List<PendingLoanInfo> GetAllPendingLoans();
        UserAndLoanDetails GetUserAndLoanDetails(string loanId);
        void RejectLoan(RejectLoanIdReason rejectLoanIdReason);
    }
}
