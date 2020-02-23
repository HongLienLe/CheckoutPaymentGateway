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

        public Customer GetCustomer(int merchantId, string email)
        {
            if (!_cPGContext.Customers.Any(x => x.email == email && x.MerchantId == merchantId))
                return null;

            var customer = _cPGContext.Customers.SingleOrDefault(x => x.MerchantId == merchantId && x.email == email);

            return customer != null ? customer : null;
        }

        //public Customer CreateCustomer(Customer customer, Card card)
        //{
        //    var customer 
        //}
    }
}
