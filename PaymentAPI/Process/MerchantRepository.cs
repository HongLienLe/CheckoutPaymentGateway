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
        private IPaymentResponse _paymentResponse;

        public MerchantRepository(CPGContext cPGContext, IPaymentResponse paymentResponse)
        {
            _cPGContext = cPGContext;
            _paymentResponse = paymentResponse;
        }

        public Merchant GetMerchant(int id)
        {
            if (!MerchantExist(id))
                return null;

            var merchant = _cPGContext.Merchants.First(x => x.MerchantId == id);

            return merchant;
        }
      
        private bool MerchantExist(int merchantId)
        {
            return _cPGContext.Merchants.Any(x => x.MerchantId == merchantId) ? true : false;
        }   

        public string StorePaymentRequestToMerchant(PaymentRequest paymentRequest)
        { 

            var merchant = GetMerchant(paymentRequest.MerchantId);

            if (merchant == null)
                return "No Merchant";

            var isWithinRange = paymentRequest.amount >= merchant.MinAmount && paymentRequest.amount <= merchant.MaxAmount;

            if (!isWithinRange)
                return $"Payment request is {paymentRequest.status}. Amount is not within range";


            paymentRequest.status = _paymentResponse.GetPaymentStatus();

            merchant.Cards.Add(paymentRequest.Card);
            merchant.PaymentRequests.Add(paymentRequest);

            _cPGContext.SaveChanges();

            var StatusOfPayment = paymentRequest.status == true ? "Success" : "Unsuccessful";
            return $"Payment request was {StatusOfPayment}.";
        }

    }
}
