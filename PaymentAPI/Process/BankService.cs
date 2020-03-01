﻿using System;
using PaymentAPI.Models;

namespace PaymentAPI.Process
{
    public sealed class BankService : IBankService
    {
        public bool isSuccessful()
        {
            Random random = new Random();

            return Convert.ToBoolean(random.Next(0, 3));
        }

        public BankPaymentResponse GetBankPaymentResponse()
        {
            var id = Guid.NewGuid();
            return new BankPaymentResponse(id,isSuccessful());
        }
    }
}
