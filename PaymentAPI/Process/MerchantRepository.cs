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

        public Merchant CreateMerchant(Merchant merchant)
        {
            if ((merchant.MinAmount > 0 || merchant.MinAmount > merchant.MaxAmount))
                return null;

            _cPGContext.Merchants.Add(merchant);
            _cPGContext.SaveChanges();

            return merchant;
        }

        public string UpdateMerchant(int id, Merchant merchant)
        {
            var unEditedMerchant = GetMerchant(id);

            if (unEditedMerchant == null)
                return null;

            unEditedMerchant.Name = merchant.Name == null ? unEditedMerchant.Name : merchant.Name;
            unEditedMerchant.MinAmount = merchant.MinAmount == unEditedMerchant.MinAmount || merchant.MinAmount == 0  ? unEditedMerchant.MinAmount : merchant.MinAmount;
            unEditedMerchant.MaxAmount = merchant.MaxAmount == unEditedMerchant.MaxAmount || merchant.MaxAmount == 0 ? unEditedMerchant.MaxAmount : merchant.MaxAmount;

            _cPGContext.SaveChanges();

            return "Updated Merchant Details";
        }

        public List<Merchant> GetAllMerchants()
        {
            return _cPGContext.Merchants.ToList();
        }

    }
}
