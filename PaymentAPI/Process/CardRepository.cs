using System;
using PaymentAPI.Data;
using PaymentAPI.Models;
using System.Linq;

namespace PaymentAPI.Process
{
    public class CardRepository : ICardRepository
    {
        private CPGContext _cPGContext;

        public CardRepository(CPGContext cPGContext)
        {
            _cPGContext = cPGContext;
        }

        public Card AddCard(int customerId, Card card)
        {

            if (_cPGContext.Cards.Where(x => x.CustomerId == customerId && x.MerchantId == card.MerchantId).Any(x => x.card_number == card.card_number))
                return null;


            var addedCard = new Card(card.card_number, card.expiry_month, card.expiry_year, card.cvv, card.name, customerId, card.MerchantId);

            _cPGContext.Cards.Add(addedCard);
            _cPGContext.SaveChanges();

            return GetCard(customerId, card.card_number, card.MerchantId);
        }

        public Card GetCard(int customerId, string cardNumber, int merchantId)
        {
            if (!_cPGContext.Cards.Any(x => x.CustomerId == customerId && x.card_number == cardNumber && x.MerchantId == merchantId))
                return null;

            return _cPGContext.Cards.First(x => x.CustomerId == customerId && x.card_number == cardNumber);
        }
    }
}
