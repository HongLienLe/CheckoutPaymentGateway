using System;
using System.Collections.Generic;
using PaymentAPI.Models;

namespace PaymentAPI.Process
{
    public interface IProcessPaymentRequest
    {
        public string StorePaymentRequestToMerchant(PaymentRequest paymentRequest);
    }
}
