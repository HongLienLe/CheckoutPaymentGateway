using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PaymentAPI.FromBodyModel;
using PaymentAPI.Models;
using PaymentAPI.Process;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PaymentAPI.Controllers
{
    [Route("api/[controller]")]
    public class CustomerController : Controller
    {
        private ICustomerRepository _customerRepository;

        public CustomerController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        [HttpGet]
        public IActionResult GetCustomer([FromBody] CustomerEntry customerEntry)
        {
            if (!ModelState.IsValid)
                return BadRequest("Model state is Invalid. Required Values : merchantId and email");

            var customer = _customerRepository.GetCustomer(customerEntry.merchantId, customerEntry.email);

            if (customer == null)
                return NotFound("Either the customer or the merchant does not exist");

            return Ok(customer);
        }

       [HttpPost()]
       public IActionResult CreateCustomer([FromBody] Customer customer)
        {

            if (!ModelState.IsValid)
                return BadRequest("Model state is Invalid. Required Values : merchantId and email");

            return Ok(new { message = "Successfully Created Customer", newCustomerEntry = _customerRepository.CreateCustomer(customer) });
        }
    }
}
