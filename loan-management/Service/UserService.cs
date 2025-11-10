using LoanManagement.Model;
using LoanManagement.Repository;

namespace LoanManagement.Service
{
    public class UserService:IUserService
    {
        IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public List<LoanType> GetAllLoans()
        {
            return _userRepository.GetAllLoans();
        }

        public bool RegisterNewUser(User user)
        {
            if (_userRepository.GetUserByEmail(user.Email) == null)
            {
                _userRepository.RegisterNewUser(user);
                return true;
            }
            return false;
        }

        public User UserLogin(EmailAndPass emailAndPass)
        {
            return _userRepository.GetUserByEmailAndPass(emailAndPass);
        }

        public bool EditUserDetails(UserDetails user)
        {
            _userRepository.EditUserDetails(user);
            return true;
        }

        public UserDetails GetUserDetails(string email)
        {
            UserDetails user = _userRepository.GetUserDetailsByEmail(email);
            return user;
        }

        public bool RequestLoan(string? email, Form2Details form2Details)
        {
            if (_userRepository.RequestLoan(email, form2Details))
            {
                return true;
            }
            throw new Exception("Internal Error");
        }
        public List<PendingLoanInfo> GetPendingLoansRequest(string? email)
        {
            return _userRepository.GetPendingLoansRequest(email);
        }

        public List<PendingLoanInfo> GetRejectedLoansRequest(string? email)
        {
            return _userRepository.GetRejectedLoansRequest(email);
        }

        public PendingLoanInfo GetRejectedLoansDetailsById(string id)
        {
            return _userRepository.GetRejectedLoansDetailsById(id);
        }

        public List<PassLoanInfo> GetNotPayedLoans(string? email)
        {
            return _userRepository.GetNotPayedLoansList(email);
        }

        public PassLoanInfo GetPassedLoansDetailsById(string id)
        {
            return _userRepository.GetPassedLoansDetailsById(id);
        }

        public PaymentDetails PayLoan(PayLoanAmountID id)
        {
            return _userRepository.PayLoan(id);
        }

        public List<PaymentDetails> PaymentReceiptsList(string email)
        {
            return _userRepository.PaymentReceiptsList(email);
        }

        public PaymentDetails GetPaymentPaymentReceipts(string id)
        {
            return _userRepository.GetPaymentPaymentReceipts(id);
        }
    }
}
