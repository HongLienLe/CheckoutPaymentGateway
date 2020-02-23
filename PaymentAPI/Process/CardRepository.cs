using System;
using PaymentAPI.Data;
using PaymentAPI.Models;

namespace PaymentAPI.Process
{
    public class CardRepository
    {
        private CPGContext _CPGContext;

        public CardRepository(CPGContext cPGContext)
        {
            _CPGContext = cPGContext;
        }

        public void CreateCard(Card card)
        {
            _CPGContext.Cards.Add(card);
            _CPGContext.SaveChanges();
        }
    }
}
