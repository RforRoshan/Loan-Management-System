using LoanManagement.Model;

namespace LoanManagement.Repository
{
    public interface IUserRepository
    {
        List<LoanType> GetAllLoans();
        User GetUserByEmail(string email);
        User GetUserByEmailAndPass(EmailAndPass emailAndPass);
        void RegisterNewUser(User user);

        void EditUserDetails(UserDetails user);
        bool RequestLoan(string? email, Form2Details form2Details);
        List<PendingLoanInfo> GetPendingLoansRequest(string? email);
        List<PendingLoanInfo> GetRejectedLoansRequest(string? email);
        PendingLoanInfo GetRejectedLoansDetailsById(string id);
        List<PassLoanInfo> GetNotPayedLoansList(string? email);
        PassLoanInfo GetPassedLoansDetailsById(string id);
        PaymentDetails PayLoan(PayLoanAmountID id);
        List<PaymentDetails> PaymentReceiptsList(string email);
        PaymentDetails GetPaymentPaymentReceipts(string id);
        UserDetails GetUserDetailsByEmail(string email);
    }
}
