using LoanManagement.Model;

namespace LoanManagement.Service
{
    public interface IAdminService
    {
        void ApproveLoan(AdminApproveLoanData adminApproveLoanData);
        Admin GetAdminDetails(EmailAndPass emailAndPass);
        List<PendingLoanInfo> GetAllPendingLoans();
        UserAndLoanDetails GetUserAndLoanDetails(string loanId);
        void RejectLoan(RejectLoanIdReason rejectLoanIdReason);
    }
}
