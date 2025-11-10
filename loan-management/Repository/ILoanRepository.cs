using LoanManagement.Model;

namespace LoanManagement.Repository
{
    public interface ILoanRepository
    {
        bool AddLoan(LoanType loanType);
        bool DeleteLoan(LoanType loanType);
        List<LoanType> GetAllLoans();
        LoanType GetLoanByName(string loanName);
    }
}
