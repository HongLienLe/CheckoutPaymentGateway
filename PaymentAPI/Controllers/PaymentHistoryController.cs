using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PaymentAPI.Process;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PaymentAPI.Controllers
{
    [Route("api/[controller]")]
    public class PaymentHistoryController : Controller
    {
        private IPaymentHistory _paymentHistory;

        public PaymentHistoryController(IPaymentHistory paymentHistory)
        {
            _paymentHistory = paymentHistory;
        }

        [HttpGet("{mercahntId}/payment/{paymentId}")]
        public IActionResult GetPaymentsById(int merchantId, int paymentId)
        {

            var response = _paymentHistory.GetPaymentRequest(merchantId, paymentId);

            if (response == null)
                return NotFound("Either or both merchant and payment Id does not exist");

            return Ok(response);
        }
    }
}
