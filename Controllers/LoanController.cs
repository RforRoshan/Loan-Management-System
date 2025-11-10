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
    public class LoanController : ControllerBase
    {
        readonly ILoanService _loanService;
        public LoanController(ILoanService loanService)
        {
            this._loanService = loanService;
        }

        [Route("AddLoan")]
        [HttpPost]
        public ActionResult AddLoans(LoanType loanType)
        {
            bool status = _loanService.AddLoan(loanType);
            return Ok(status);
        }
        [Route("DeleteLoan")]
        [HttpPost]
        public ActionResult DeleteLoans(string loanName)
        {
            bool status = _loanService.DeleteLoanByName(loanName);
            return Ok(status);
        }
        [Route("GetAllLoans")]
        [HttpGet]
        public ActionResult GetAllLoans()
        {
            List<LoanType> loanTypes = _loanService.GetAllLoans();
            return Ok(loanTypes);
        }
    }
}
