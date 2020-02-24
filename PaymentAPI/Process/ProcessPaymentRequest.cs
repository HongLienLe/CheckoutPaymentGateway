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
        private ICustomerRepository _customerRepository;

        public ProcessPaymentRequest(IMerchantRepository merchantRepository, ICustomerRepository customerRepository)
        {
            _merchantRepository = merchantRepository;
            _customerRepository = customerRepository;
        }

        //Method ProcessPayment

            //Currency check if not - return null; Currency is not supported
            //Merchant Check if not - either merchant acc does not exist or amount out of range
            //Customer Check - check card number 

        public void ProcessingPaymentRequest(PaymentRequestEntryToBank paymentRequestEntry)
        {
            var merchant = MerchantValidationCheck(paymentRequestEntry);
            if (merchant == null)
                return;

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

        public Customer CustomerValidationCheck(PaymentRequestEntryToBank paymentRequestEntry)
        {
            var merchantId = paymentRequestEntry.paymentRequest.MerchantId;
            var requestedCustomer = paymentRequestEntry.paymentRequest.Customer;
            var customer = _customerRepository.GetCustomer(requestedCustomer.MerchantId, requestedCustomer.email);

            return customer != null ? customer : _customerRepository.CreateCustomer(merchantId,requestedCustomer);
        }

        //public Card CardValidationCheck(PaymentRequestEntryToBank paymentRequestEntry)
        //{

        //}

        public bool isPaymentTypeRecurring(PaymentRequestEntryToBank paymentRequestEntry)
        {
            var paymentType = paymentRequestEntry.paymentRequest.payment_type;

            return paymentType == PaymentType.Recurring ? true : false;
        }

    }
}
