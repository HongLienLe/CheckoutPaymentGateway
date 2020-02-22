using System;
using PaymentAPI.Models;

namespace PaymentAPI.Process
{
    public interface IMerchantRepository
    {
        public Merchant GetMerchant(int id);
        public string UpdateMerchant(int id, Merchant merchant);
        public string CreateMerchant(Merchant merchant);
    }
}
