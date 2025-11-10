using LoanManagement.Model;

namespace LoanManagement.Service
{
    public interface ILoanService
    {
        bool AddLoan(LoanType loanType);
        List<LoanType> GetAllLoans();
        bool DeleteLoanByName(string loanName);
    }
}
