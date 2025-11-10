using LoanManagement.Model;
using LoanManagement.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LoanManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        readonly IUserService _userService;
        readonly ITokenGenerator _tokenGenerator;
        public UserController(IUserService userService, ITokenGenerator tokenGenerator)
        {
            this._userService = userService;
            _tokenGenerator = tokenGenerator;
        }

        [Route("GetAllLoans")]
        [HttpGet]
        public ActionResult GetAllLoans()
        {
            List<LoanType> loanTypes = _userService.GetAllLoans();
            return Ok(loanTypes);
        }

        [Route("Login")]
        [HttpPost]
        public ActionResult Login(EmailAndPass emailAndPass)
        {
            User user = _userService.UserLogin(emailAndPass);
            if (user != null)
            {
                string tokenString = _tokenGenerator.GenerateJSONWebToken(user);
                //HttpContext.Session.SetString("USERTOKEN", tokenString);
                return Ok(tokenString);
            }
            return Ok(null);

        }

        [Route("Register")]
        [HttpPost]
        public ActionResult Register(User user)
        {
            bool status = _userService.RegisterNewUser(user);
            return Ok(status);

        }













        [Route("GetUserDetails")]
        [HttpPost]
        public ActionResult GetUserDetails(string email)
        {
            UserDetails userDetails = _userService.GetUserDetails(email);
            return Ok(userDetails);
        }
        [Route("EditUserDetails")]
        [HttpPut]
        public ActionResult EditUserDetails(UserDetails user)
        {
            _userService.EditUserDetails(user);

            return Ok(true);
        }



        [Route("RequestLoan")]
        [HttpPost]
        public ActionResult RequestLoan(string email,Form2Details form2Details)
        {
            _userService.RequestLoan(email, form2Details);
            return Ok(true);
        }




        [Route("PendingLoans")]
        [HttpPost]
        public ActionResult ShowPendingLoansRequest(string email)
        {
            List<PendingLoanInfo> userLoansInfoList = _userService.GetPendingLoansRequest(email);
            return Ok(userLoansInfoList);
        }
        [Route("RejectedLoans")]
        [HttpPost]
        public ActionResult ShowRejectedLoansRequest(string email)
        {
            List<PendingLoanInfo> userLoansInfoList = _userService.GetRejectedLoansRequest(email);
            return Ok(userLoansInfoList);
        }
        [Route("RejectedLoansDetails")]
        [HttpPost]
        public ActionResult ShowRejectedLoanDetails(string id)
        {
            PendingLoanInfo loanInfo = _userService.GetRejectedLoansDetailsById(id);
            return Ok(loanInfo);
        }
        [Route("NotPayedLoans")]
        [HttpPost]
        public ActionResult ShowNotPayedLoans(string email)
        {
            List<PassLoanInfo> notPayedLoansList = _userService.GetNotPayedLoans(email);
            return Ok(notPayedLoansList);
        }

        [Route("NotPayLoanDetails")]
        [HttpPost]
        public ActionResult ShowNotPayLoanDetails(string id)
        {
            PassLoanInfo loanInfo = _userService.GetPassedLoansDetailsById(id);
            return Ok(loanInfo);
        }
        [Route("PayLoan")]
        [HttpPost]
        public ActionResult PayLoan(PayLoanAmountID payLoanAmountID)
        {
            PaymentDetails paymentDetails = _userService.PayLoan(payLoanAmountID);
            return Ok(paymentDetails);
        }
        [Route("PaymentHistory")]
        [HttpPost]
        public ActionResult PaymentHistory(string email)
        {
            List<PaymentDetails> paymentDetailsList = _userService.PaymentReceiptsList(email);
            return Ok(paymentDetailsList);
        }
        [Route("PaymentHistoryByOrderId")]
        [HttpPost]
        public ActionResult PaymentHistoryByOrderId(string id)
        {
            PaymentDetails paymentDetails = _userService.GetPaymentPaymentReceipts(id);
            return Ok(paymentDetails);
        }
    }
}