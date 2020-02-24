using System;
using PaymentAPI.Models;

namespace PaymentAPI.Process
{
    public interface ICardRepository
    {
        public Card AddCard(int customerId, Card card);
        public Card GetCard(int customerId, string cardNumber, int merchantId);
    }
}
