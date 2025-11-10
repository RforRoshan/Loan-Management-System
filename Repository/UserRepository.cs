using LoanManagement.Context;
using LoanManagement.Model;
using Microsoft.EntityFrameworkCore;

namespace LoanManagement.Repository
{
    public class UserRepository:IUserRepository
    {
        LoanDbContext _loanDbContext;
        public UserRepository(LoanDbContext loanDbContext)
        {
            _loanDbContext=loanDbContext;
        }

        public List<LoanType> GetAllLoans()
        {
            return _loanDbContext.LoanTypes.ToList();
        }

        public void RegisterNewUser(User user)
        {
            _loanDbContext.Users.Add(user);
            _loanDbContext.SaveChanges();
            _loanDbContext.UsersDetails.Add(new UserDetails { Email = user.Email });
            _loanDbContext.SaveChanges();
        }
        public User GetUserByEmail(string email)
        {
            return _loanDbContext.Users.Where(u => u.Email == email).FirstOrDefault();
        }

        public UserDetails GetUserDetailsByEmail(string email)
        {
            return _loanDbContext.UsersDetails.Where(u => u.Email == email).FirstOrDefault();
        }
        public void EditUserDetails(UserDetails user)
        {
            _loanDbContext.Entry<UserDetails>(user).State = EntityState.Modified;
            _loanDbContext.SaveChanges();
        }
        public bool RequestLoan(string? email, Form2Details form2Details)
        {
            PendingLoanInfo loanInfo = new PendingLoanInfo();
            loanInfo.UserEmail = email;
            loanInfo.LoanType = form2Details.LoanType;
            loanInfo.LoanAmount = form2Details.LoanAmount;
            DateTime dateTime = DateTime.Now;
            loanInfo.LoanId = dateTime.ToString("yyyyMMddhhmmss");
            loanInfo.LoanDate = dateTime.ToString("dd/MM/yyyy");
            loanInfo.LoanTime = dateTime.ToString("h:mm:ss tt");
            loanInfo.LoanDurationInMonths = form2Details.LoanDurationInMonths;

            loanInfo.LoanNotPass = false;
            _loanDbContext.PendingLoansInfoTable.Add(loanInfo);
            return _loanDbContext.SaveChanges() == 1 ? true : false;
        }
        public User GetUserByEmailAndPass(EmailAndPass ep)
        {
            User user = _loanDbContext.Users.Where(u => u.Email == ep.Email && u.Password == ep.Password).FirstOrDefault();
            return user;
        }
        public List<PendingLoanInfo> GetPendingLoansRequest(string? email)
        {
            return _loanDbContext.PendingLoansInfoTable.Where(u => u.UserEmail == email && u.LoanNotPass == false).ToList();
        }

        public List<PendingLoanInfo> GetRejectedLoansRequest(string? email)
        {
            return _loanDbContext.PendingLoansInfoTable.Where(u => u.UserEmail == email && u.LoanNotPass == true).ToList();
        }

        public PendingLoanInfo GetRejectedLoansDetailsById(string id)
        {
            return _loanDbContext.PendingLoansInfoTable.Where(u => u.LoanId == id).FirstOrDefault();
        }

        public List<PassLoanInfo> GetNotPayedLoansList(string? email)
        {
            return _loanDbContext.PassedLoansInfoTable.Where(u => u.UserEmail == email && u.LoanAmountLeft > 0).ToList();
        }

        public PassLoanInfo GetPassedLoansDetailsById(string id)
        {
            return _loanDbContext.PassedLoansInfoTable.Where(u => u.LoanId == id).FirstOrDefault();
        }

        public PaymentDetails PayLoan(PayLoanAmountID id)
        {
            PaymentDetails paymentDetails = new PaymentDetails();
            DateTime dateTime = DateTime.Now;
            paymentDetails.OrderId = "RKS00" + dateTime.ToString("yyMMddhhmmss");
            paymentDetails.LoanId = id.LoanId;
            paymentDetails.PayedAmount = id.Amount;
            PassLoanInfo passLoanInfo = _loanDbContext.PassedLoansInfoTable.Where(u => u.LoanId == id.LoanId).FirstOrDefault();
            paymentDetails.UserEmail = passLoanInfo.UserEmail;
            paymentDetails.LoanType = passLoanInfo.LoanType;
            UserDetails userDetails = _loanDbContext.UsersDetails.Where(u => u.Email == passLoanInfo.UserEmail).FirstOrDefault();
            paymentDetails.Name = userDetails.Fname + " " + userDetails.Sname;
            paymentDetails.PaymentDate = dateTime.ToString("dd/MM/yyyy");
            paymentDetails.PaymentTime = dateTime.ToString("h:mm:ss tt");
            paymentDetails.AmountLeft = (float)passLoanInfo.LoanAmountLeft - id.Amount;
            passLoanInfo.LoanAmountLeft = paymentDetails.AmountLeft;
            _loanDbContext.PaymentsDetailsTable.Add(paymentDetails);
            _loanDbContext.SaveChanges();
            _loanDbContext.Entry<PassLoanInfo>(passLoanInfo).State = EntityState.Modified;
            _loanDbContext.SaveChanges();

            return paymentDetails;
        }

        public List<PaymentDetails> PaymentReceiptsList(string email)
        {
            return _loanDbContext.PaymentsDetailsTable.Where(u => u.UserEmail == email).ToList();
        }

        public PaymentDetails GetPaymentPaymentReceipts(string id)
        {
            return _loanDbContext.PaymentsDetailsTable.Where(u => u.OrderId == id).FirstOrDefault();
        }

    }
}
