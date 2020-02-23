using System;
using System.Linq;
using PaymentAPI.Data;
using PaymentAPI.Models;

namespace PaymentAPI.Process
{
    public class CustomerRepository
    {
        private CPGContext _cPGContext;

        public CustomerRepository(CPGContext CPGContext)
        {
            _cPGContext = CPGContext;
        }

        public Customer GetCustomer(string cardAccountNo)
        {
            if (!_cPGContext.Cards.Any(x => x.card_number == cardAccountNo))
                return null;

            var customer = _cPGContext.Cards.First(x => x.card_number == cardAccountNo).Customer;

            return customer;
        }
    }
}
