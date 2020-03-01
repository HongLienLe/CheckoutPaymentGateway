using System;
using System.Collections.Generic;
using System.Linq;
using PaymentAPI.Data;
using PaymentAPI.Models;

namespace PaymentAPI.Process
{
    public sealed class ProcessPaymentRequest : IProcessPaymentRequest
    {
        private CPGContext _cPGContext;
        private IBankService _bankService;

        public ProcessPaymentRequest(CPGContext cPGContext, IBankService bankService)
        {
            _cPGContext = cPGContext;
            _bankService = bankService;
        }

        private Merchant GetMerchant(int id)
        {
            if (!_cPGContext.Merchants.Any(x => x.MerchantId == id))
                return null;

            var merchant = _cPGContext.Merchants.First(x => x.MerchantId == id);
            return merchant;
        }
     
        public string StorePaymentRequestToMerchant(PaymentRequest paymentRequest)
        {

            var merchant = GetMerchant(paymentRequest.MerchantId);

            if (merchant == null)
                return null;

            var isWithinRange = paymentRequest.amount >= merchant.MinAmount && paymentRequest.amount <= merchant.MaxAmount;

            if (!isWithinRange)
                return $"Amount is not within range. Min Amount = {merchant.MinAmount} - {merchant.MaxAmount}";

            merchant.PaymentRequests.Add(paymentRequest);
            merchant.Cards.Add(paymentRequest.Card);

            _cPGContext.SaveChanges();

            paymentRequest.status = _bankService.GetBankPaymentResponse();


            var statusToString = paymentRequest.status.Status == true ? "Success" : "Unsuccessful";

            return $"Payment has been process and stored. PaymentId : {paymentRequest.PaymentRequestId} Status : {statusToString} ";
        }



    }
}
