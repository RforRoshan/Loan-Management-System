using LoanManagement.Model;
using LoanManagement.Service;
using LoanManagement.SRP;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LoanManagement.Controllers
{
    [CustomExceptionFilter]
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        readonly IAdminService _adminService;
        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        [Route("AdminLogin")]
        [HttpPost]
        public ActionResult Login(EmailAndPass emailAndPass)
        {
            Admin adminDetails = _adminService.GetAdminDetails(emailAndPass);
            return Ok(adminDetails);

        }
        [Route("ShowPendingLoans")]
        [HttpGet]
        public ActionResult GetPendingLoansList()
        {
            List<PendingLoanInfo> pendingLoanInfosList = _adminService.GetAllPendingLoans();
            return Ok(pendingLoanInfosList);
        }
        [Route("ShowApplyLoanDetails")]
        [HttpPost]
        public ActionResult GetApplyLoanDetails(string loanId)
        {
            UserAndLoanDetails userAndLoanDetails = _adminService.GetUserAndLoanDetails(loanId);
            return Ok(userAndLoanDetails);
        }

        [Route("ApproveLoan")]
        [HttpPost]
        public ActionResult LoanApprove(AdminApproveLoanData adminApproveLoanData)
        {
            _adminService.ApproveLoan(adminApproveLoanData);
            return Ok(true);
        }
        [Route("RejectLoan")]
        [HttpPost]
        public ActionResult LoanReject(RejectLoanIdReason rejectLoanIdReason)
        {
            _adminService.RejectLoan(rejectLoanIdReason);
            return Ok(true);
        }
    }
}
