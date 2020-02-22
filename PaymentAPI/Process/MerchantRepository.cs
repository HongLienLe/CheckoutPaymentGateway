using System;
using System.Linq;
using PaymentAPI.Data;
using PaymentAPI.Models;

namespace PaymentAPI.Process
{
    public class MerchantRepository : IMerchantRepository
    {
        private CPGContext _cPGContext;

        public MerchantRepository(CPGContext cPGContext)
        {
            _cPGContext = cPGContext;
        }

        public Merchant GetMerchant(int id)
        {
            var merchant = _cPGContext.Merchants.First(x => x.MerchantId == id);

            return merchant;
        }

    }
}
