using System;
using PaymentAPI.Process;

namespace PaymentAPI.Models
{
    public class PaymentResponse : IPaymentResponse
    {
        public bool GetPaymentStatus()
        {
            Random random = new Random();

            return Convert.ToBoolean(random.Next(0, 3));
        }
    }
}
