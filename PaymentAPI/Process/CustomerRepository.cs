using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PaymentAPI.Data;
using PaymentAPI.Models;

namespace PaymentAPI.Process
{
    public class CustomerRepository : ICustomerRepository
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

            return _cPGContext.Customers.First(x => x.MerchantId == merchantId && x.email == email);
        }

        public Customer CreateCustomer(int merchantId, Customer customer)
        {
            if (_cPGContext.Customers.Any(x => x.email == customer.email && x.MerchantId == merchantId))
                return null;

            var newCustomer = new Customer(customer.email, customer.name, merchantId);

            _cPGContext.Customers.Add(newCustomer);

            _cPGContext.SaveChanges();

            return GetCustomer(customer.MerchantId, customer.email);
        }
    }
}
