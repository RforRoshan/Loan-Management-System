using LoanManagement.Context;
using LoanManagement.Model;
using Microsoft.EntityFrameworkCore;

namespace LoanManagement.Repository
{
    public class LoanRepository: ILoanRepository
    {

        LoanDbContext _loanDbContext;
        public LoanRepository(LoanDbContext loanDbContext)
        {
            _loanDbContext = loanDbContext;
        }

        public bool AddLoan(LoanType loanType)
        {
            _loanDbContext.LoanTypes.Add(loanType);
            return _loanDbContext.SaveChanges() == 1 ? true : false;
        }

        public bool DeleteLoan(LoanType loanType)
        {
            _loanDbContext.Entry<LoanType>(loanType).State = EntityState.Deleted;
            return _loanDbContext.SaveChanges() == 1 ? true : false;
        }

        public List<LoanType> GetAllLoans()
        {
            return _loanDbContext.LoanTypes.ToList();
        }

        public LoanType GetLoanByName(string loanName)
        {
            return _loanDbContext.LoanTypes.Where(u => u.LoanName == loanName).FirstOrDefault();
        }

    }
}
