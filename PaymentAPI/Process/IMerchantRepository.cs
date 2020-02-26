using System;
using System.Collections.Generic;
using PaymentAPI.Models;
using PaymentAPI.FromBodyModel;


namespace PaymentAPI.Process
{
    public interface IMerchantRepository
    {
        public List<Merchant> GetAllMerchants();
        public Merchant GetMerchant(int id);
        public string UpdateMerchant(int id, Merchant merchant);
        public string CreateMerchant(Merchant merchant);
        public string StorePaymentRequestToMerchant(PaymentRequest paymentRequest);
    }
}
