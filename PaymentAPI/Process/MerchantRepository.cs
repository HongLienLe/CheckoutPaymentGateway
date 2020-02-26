using System;
using System.Collections.Generic;
using System.Linq;
using PaymentAPI.Data;
using PaymentAPI.FromBodyModel;
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
            if (!MerchantExist(id))
                return null;

            var merchant = _cPGContext.Merchants.First(x => x.MerchantId == id);

            return merchant;
        }

        public string CreateMerchant(Merchant merchant)
        {

            _cPGContext.Merchants.Add(merchant);
            _cPGContext.SaveChanges();

            return $"Successfully created new Merchant";
        }

        public string UpdateMerchant(int id, Merchant merchant)
        {
            if (isMinMoreThanMaxAmount(merchant))
                return "Min is more than Max Value";

            var unEditedMerchant = GetMerchant(id);

            if (unEditedMerchant == null)
                return null;

            unEditedMerchant.Name = merchant.Name;
            unEditedMerchant.MinAmount = merchant.MinAmount;
            unEditedMerchant.MaxAmount = merchant.MaxAmount;

            _cPGContext.SaveChanges();

            return "Updated Merchant Details";
        }

        public List<Merchant> GetAllMerchants()
        {
            return _cPGContext.Merchants.ToList();
        }

        private bool MerchantExist(int merchantId)
        {
            return _cPGContext.Merchants.Any(x => x.MerchantId == merchantId) ? true : false;
        }

        private bool isMinMoreThanMaxAmount(Merchant merchant)
        {
            return merchant.MinAmount > merchant.MaxAmount ? false : true;
        }

        public string StorePaymentRequestToMerchant(PaymentRequest paymentRequest)
        { 

            var merchant = GetMerchant(paymentRequest.MerchantId);

            if (merchant == null)
                return "No Merchant";

            merchant.Cards.Add(paymentRequest.Card);
            merchant.PaymentRequests.Add(paymentRequest);

            _cPGContext.SaveChanges();

            return "Saved PaymentRequest to merchant acc";
        }
    }
}
