using System;
using PaymentAPI.Models;
namespace PaymentAPI.Process
{
    public class ProcessPaymentRequest
    {
        public ProcessPaymentRequest()
        {
           

        }

        public bool isAmountWithInRange(PaymentRequest paymentRequest)
        {
            var amount = paymentRequest.amount;

            return amount < 0 || amount > 10000 ? true : false;
        }
    }
}
