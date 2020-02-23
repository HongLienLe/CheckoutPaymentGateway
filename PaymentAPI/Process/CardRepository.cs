using System;
using PaymentAPI.Data;
using PaymentAPI.Models;
using System.Linq;

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

        //public Card GetCard(string cardNo)
        //{
        //    return _CPGContext.Cards.Where(x => x.card_number == cardNo);
        //}
    }
}
