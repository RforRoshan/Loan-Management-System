using LoanManagement.Model;
using LoanManagement.Repository;

namespace LoanManagement.Service
{
    public class AdminService : IAdminService
    {
        IAdminRepository _adminRepository;
        public AdminService(IAdminRepository adminRepository)
        {
            _adminRepository = adminRepository;
        }
        public void ApproveLoan(AdminApproveLoanData adminApproveLoanData)
        {
            _adminRepository.ApproveLoan(adminApproveLoanData);
        }

        public Admin GetAdminDetails(EmailAndPass emailAndPass)
        {
            return _adminRepository.GetAdminDetails(emailAndPass);
        }

        public List<PendingLoanInfo> GetAllPendingLoans()
        {
            return _adminRepository.GetAllPendingLoans();
        }

        public UserAndLoanDetails GetUserAndLoanDetails(string loanId)
        {
            return _adminRepository.GetUserAndLoanDetails(loanId);
        }

        public void RejectLoan(RejectLoanIdReason rejectLoanIdReason)
        {
            _adminRepository.RejectLoan(rejectLoanIdReason);
        }
    }
}
