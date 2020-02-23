using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PaymentAPI.Models;
using PaymentAPI.Process;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PaymentAPI.Controllers
{
    [Route("api/[controller]")]
    public class MerchantController : Controller
    {
        private IMerchantRepository _merchantRepository;

        public MerchantController(IMerchantRepository merchantRepository)
        {
            _merchantRepository = merchantRepository;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult GetMerchant(int id)
        {
            var merchant = _merchantRepository.GetMerchant(id);

            if(merchant == null)
                return NotFound($"Merchant {id} does not exist");

            return Ok(merchant);
        }

        [HttpPost("Update/{id}")]
        public IActionResult UpdateMerchant(int id, [FromBody] Merchant updatedMerchant)
        {
            var returnValue = _merchantRepository.UpdateMerchant(id, updatedMerchant);

            if (returnValue == null)
                return NotFound($"Merchant {id} does not exist");

            return Ok(returnValue);
        }

        [HttpPost("Create")]
        public IActionResult CreateMerchant([FromBody] Merchant merchant)
        {
            return Ok(_merchantRepository.CreateMerchant(merchant));
        }

    }
}
