using System;
using PaymentAPI.Models;

namespace PaymentAPI.Process
{
    public interface IPaymentHistory
    {
        public PaymentResponse GetPaymentRequest(int merchantId, int paymentId);
    }
}
