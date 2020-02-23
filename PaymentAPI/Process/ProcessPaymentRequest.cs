using System;
using Microsoft.AspNetCore.Mvc;
using PaymentAPI.Data;
using PaymentAPI.FromBodyModel;
using PaymentAPI.Models;
namespace PaymentAPI.Process
{
    public class ProcessPaymentRequest
    {
        private IMerchantRepository _merchantRepository;

        public ProcessPaymentRequest(IMerchantRepository merchantRepository)
        {
            _merchantRepository = merchantRepository;
        }

        public Merchant MerchantValidationCheck(PaymentRequestEntryToBank paymentRequestEntry)
        {
            var merchant = _merchantRepository.GetMerchant(paymentRequestEntry.paymentRequest.MerchantId);
            if (merchant == null)
                return null;

            var minValue = merchant.MinAmount;
            var maxValue = merchant.MaxAmount;

            var paymentRequest = paymentRequestEntry.paymentRequest;

            if (paymentRequest.amount! >= minValue && paymentRequest.amount! <= maxValue)
                return null;

            return merchant;     
        }

        public bool isPaymentTypeRecurring(PaymentRequestEntryToBank paymentRequestEntry)
        {
            var paymentType = paymentRequestEntry.paymentRequest.payment_type;

            return paymentType == PaymentType.Recurring ? true : false;
        }

        //public Customer GetCustomer(PaymentRequestEntryToBank paymentRequestEntry)
        //{
        //    var Customer = paymentRequestEntry.paymentRequest.Customer;
        //}

    }
}
