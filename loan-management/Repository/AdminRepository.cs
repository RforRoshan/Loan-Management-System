using LoanManagement.Context;
using LoanManagement.Model;
using Microsoft.EntityFrameworkCore;

namespace LoanManagement.Repository
{
    public class AdminRepository : IAdminRepository
    {
        LoanDbContext _loanDbContext;
        public AdminRepository(LoanDbContext loanDbContext)
        {
            _loanDbContext = loanDbContext;
        }
        public void ApproveLoan(AdminApproveLoanData adminApproveLoanData)
        {
            PendingLoanInfo loanInfo = _loanDbContext.PendingLoansInfoTable.Where(u => u.LoanId == adminApproveLoanData.LoanId).FirstOrDefault();
            _loanDbContext.Entry(loanInfo).State = EntityState.Deleted;
            _loanDbContext.SaveChanges();


            PassLoanInfo passLoanInfo = new PassLoanInfo();
            passLoanInfo.LoanId = loanInfo.LoanId;
            passLoanInfo.UserEmail = loanInfo.UserEmail;
            passLoanInfo.LoanType = loanInfo.LoanType;
            passLoanInfo.LoanAmount = loanInfo.LoanAmount;
            passLoanInfo.LoanDate = loanInfo.LoanDate;
            passLoanInfo.LoanTime = loanInfo.LoanTime;
            passLoanInfo.ProcessingFee = adminApproveLoanData.ProcessingFee;
            passLoanInfo.InterestRate = adminApproveLoanData.InterestRate;
            passLoanInfo.InterestAmount = (float)(loanInfo.LoanAmount * Math.Pow((1 + passLoanInfo.InterestRate / 100), (double)loanInfo.LoanDurationInMonths) / 12);
            passLoanInfo.LoanAmountLeft = loanInfo.LoanAmount + passLoanInfo.InterestAmount;
            passLoanInfo.LoanDurationInMonths = (int)loanInfo.LoanDurationInMonths;
            int month = int.Parse(loanInfo.LoanDate.Substring(3, 2));
            int year = int.Parse(loanInfo.LoanDate.Substring(6, 4));
            month += (int)loanInfo.LoanDurationInMonths % 12;
            year += (int)loanInfo.LoanDurationInMonths / 12;
            passLoanInfo.LoanPayDate = loanInfo.LoanDate.Substring(0, 3) + month.ToString() + "-" + year.ToString();

            _loanDbContext.PassedLoansInfoTable.Add(passLoanInfo);
            _loanDbContext.SaveChanges();
        }

        public Admin GetAdminDetails(EmailAndPass ep)
        {
            return _loanDbContext.AdminsTable.Where(u => u.Email == ep.Email && u.Password == ep.Password).FirstOrDefault();
        }

        public List<PendingLoanInfo> GetAllPendingLoans()
        {
            return _loanDbContext.PendingLoansInfoTable.Where(u => u.LoanNotPass == false).ToList();
        }

        public UserAndLoanDetails GetUserAndLoanDetails(string id)
        {
            UserAndLoanDetails userAndLoanDetails = new UserAndLoanDetails();
            userAndLoanDetails.LoanInfo = _loanDbContext.PendingLoansInfoTable.Where(u => u.LoanId == id).FirstOrDefault();
            string email = userAndLoanDetails.LoanInfo.UserEmail;
            userAndLoanDetails.UserInfo = _loanDbContext.UsersDetails.Where(u => u.Email == email).FirstOrDefault();
            return userAndLoanDetails;
        }

        public void RejectLoan(RejectLoanIdReason rejectLoanIdReason)
        {
            PendingLoanInfo loanInfo = _loanDbContext.PendingLoansInfoTable.Where(u => u.LoanId == rejectLoanIdReason.LoanId).FirstOrDefault();
            loanInfo.LoanNotPass = true;
            loanInfo.LoanNotPassReason = rejectLoanIdReason.LoanNotPassReason;
            _loanDbContext.Entry<PendingLoanInfo>(loanInfo).State = EntityState.Modified;
            _loanDbContext.SaveChanges();
        }
    }
}
