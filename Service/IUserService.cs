using LoanManagement.Model;

namespace LoanManagement.Service
{
    public interface IUserService
    {
        List<LoanType> GetAllLoans();
        bool RegisterNewUser(User user);
        User UserLogin(EmailAndPass emailAndPass);
        bool EditUserDetails(UserDetails user);
        UserDetails GetUserDetails(string email);
        bool RequestLoan(string? email, Form2Details form2Details);
        List<PendingLoanInfo> GetPendingLoansRequest(string? email);
        List<PendingLoanInfo> GetRejectedLoansRequest(string? email);
        PendingLoanInfo GetRejectedLoansDetailsById(string id);
        List<PassLoanInfo> GetNotPayedLoans(string? email);
        PassLoanInfo GetPassedLoansDetailsById(string id);
        PaymentDetails PayLoan(PayLoanAmountID id);
        List<PaymentDetails> PaymentReceiptsList(string? email);
        PaymentDetails GetPaymentPaymentReceipts(string id);
    }
}
