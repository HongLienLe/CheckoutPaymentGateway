using System;
using System.Collections.Generic;
using System.Linq;
using PaymentAPI.Data;
using PaymentAPI.Models;

namespace PaymentAPI.Process
{
    public class ProcessPaymentRequest : IProcessPaymentRequest
    {
        private CPGContext _cPGContext;

        public ProcessPaymentRequest(CPGContext cPGContext)
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

            merchant.Cards.Add(paymentRequest.Card);
            merchant.PaymentRequests.Add(paymentRequest);

            paymentRequest.status = SendPaymentRequestToBank();

            _cPGContext.SaveChanges();

            var statusToString = paymentRequest.status == true ? "Success" : "Unsuccessfull";

            return $"Payment has been process and stored. PaymentId : {paymentRequest.PaymentRequestId} response : {statusToString} ";
        }

        private bool SendPaymentRequestToBank()
        {
            Random random = new Random();

            return Convert.ToBoolean(random.Next(0, 3));
        }

    }
}
