using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PaymentAPI.Models;
using PaymentAPI.Process;

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
            if (updatedMerchant.MinAmount > updatedMerchant.MaxAmount || updatedMerchant.MinAmount == 0 || updatedMerchant.MaxAmount == 0)
                return BadRequest("Min Value can not be more than Max value or equal to");

            var returnValue = _merchantRepository.UpdateMerchant(id, updatedMerchant);

            if (returnValue == null)
                return NotFound($"Merchant {id} does not exist");

            return Ok(returnValue);
        }

        [HttpPost("Create")]
        public IActionResult CreateMerchant([FromBody] Merchant merchant)
        {
            if (!ModelState.IsValid)
                return BadRequest("Model state is Invalid");

            if (merchant.MinAmount > merchant.MaxAmount || merchant.MinAmount < 0 || merchant.MaxAmount < 0)
                return BadRequest("Min Value can not be more than Max value or less than 0");

            return Ok(_merchantRepository.CreateMerchant(merchant));
        }

        [HttpGet()]
        public IActionResult GetMerchants()
        {
            var merchant = _merchantRepository.GetAllMerchants();

            if(merchant == null)
                return NotFound("There are no Merchants");

            return Ok(merchant); 
        }

    }
}
