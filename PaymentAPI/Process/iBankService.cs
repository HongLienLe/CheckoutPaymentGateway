using System;
using PaymentAPI.Models;

namespace PaymentAPI.Process
{
    public interface IBankService
    {
        public BankPaymentResponse GetBankPaymentResponse();
    }
}
