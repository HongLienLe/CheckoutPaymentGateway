using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PaymentAPI.Models;
using PaymentAPI.Process;

namespace PaymentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProcessPaymentRequestApiController : Controller
    {
        private IProcessPaymentRequest _processPaymentRequest;

        public ProcessPaymentRequestApiController(IProcessPaymentRequest processPaymentRequest)
        {
            _processPaymentRequest = processPaymentRequest;
        }

        [HttpPost]
        public IActionResult PostRequest([FromBody]PaymentRequest paymentRequest)
        {
            var response = _processPaymentRequest.StorePaymentRequestToMerchant(paymentRequest);

            return Ok(response);
        }
    }
}
