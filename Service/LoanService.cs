using LoanManagement.Exceptions;
using LoanManagement.Model;
using LoanManagement.Repository;

namespace LoanManagement.Service
{
    public class LoanService:ILoanService
    {
        ILoanRepository _loanRepository;
        public LoanService(ILoanRepository loanRepository)
        {
            _loanRepository = loanRepository;
        }

        public bool AddLoan(LoanType loanType)
        {
            if (_loanRepository.GetLoanByName(loanType.LoanName)!=null)
            {
                throw new MyException("Loan already present");
            }
            return _loanRepository.AddLoan(loanType);
        }

        public bool DeleteLoanByName(string loanName)
        {
            LoanType loanType = _loanRepository.GetLoanByName(loanName);
            if (loanType == null)
            {
                throw new MyException("Loan not found");
            }
            return _loanRepository.DeleteLoan(loanType);
        }

        public List<LoanType> GetAllLoans()
        {
            return _loanRepository.GetAllLoans();
        }
    }
}
