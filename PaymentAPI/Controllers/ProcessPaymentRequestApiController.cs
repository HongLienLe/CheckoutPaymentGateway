using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PaymentAPI.FromBodyModel;
using PaymentAPI.Models;
using PaymentAPI.Process;

namespace PaymentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProcessPaymentRequestApiController : Controller
    {
        private IMerchantRepository _merchantRepository;

        public ProcessPaymentRequestApiController(IMerchantRepository merchantRepository)
        {
            _merchantRepository = merchantRepository;
        }

        [HttpPost]
        public IActionResult PostRequest([FromBody]PaymentRequest paymentRequest)
        {
            var response = _merchantRepository.StorePaymentRequestToMerchant(paymentRequest);

            return Ok(response);
        }
    }
}
