using System;
using System.Collections.Generic;
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
            if (!_cPGContext.Merchants.Any(x => x.MerchantId == id))
                return null;

            var merchant = _cPGContext.Merchants.First(x => x.MerchantId == id);

            return merchant;
        }

        public string CreateMerchant(Merchant merchant)
        {
            _cPGContext.Add(merchant);
            _cPGContext.SaveChanges();
            var newMerchantId = _cPGContext.Merchants.Find(merchant);

            return $"Successfully created new Merchant. Id : {newMerchantId}";
        }

        public string UpdateMerchant(int id, Merchant merchant)
        {
            var unEditedMerchant = GetMerchant(id);

            if (unEditedMerchant == null)
                return null;

            unEditedMerchant.Name = merchant.Name;
            unEditedMerchant.UpperBound = merchant.UpperBound;

            _cPGContext.SaveChanges();

            return "Updated Merchant Details";
        }

        public List<Merchant> GetAllMerchants()
        {
            return _cPGContext.Merchants.ToList();
        }
    }
}
