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
    public class CardController : ControllerBase
    {
        private ICardRepository _cardRepository;

        public CardController(ICardRepository cardRepository)
        {
            _cardRepository = cardRepository;
        }

        [HttpGet]
        public IActionResult GetCard([FromBody]CardEntry cardEntry)
        {
            if (!ModelState.IsValid)
                return BadRequest("Model state is Invalid. Required Values : customerId, cardNumber ");

            var card = _cardRepository.GetCard(cardEntry.customerId, cardEntry.cardNumber, cardEntry.merchantId);

            if (card == null)
                return NotFound("Either Customer or merchant does not exist or card number");

            return Ok(card);
        }

        [HttpPost]
        public IActionResult AddCard([FromBody]Card card)
        {
            var newCard = _cardRepository.AddCard(card.CustomerId, card);

            if (newCard == null)
                return Conflict("Card already exist");

            return Ok(new { message = "Successfully Added New Card", card = _cardRepository.AddCard(card.CustomerId, card) });
        }


    }
}
