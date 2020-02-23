using System;
using PaymentAPI.Models;

namespace PaymentAPI.Process
{
    public interface ICustomerRepository
    {
        public Customer GetCustomer(int merchantId, string email);
        public Customer CreateCustomer(Customer customer);
    }
}
