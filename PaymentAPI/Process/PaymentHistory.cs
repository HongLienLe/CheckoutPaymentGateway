using System;
using System.Linq;
using PaymentAPI.Data;
using PaymentAPI.Models;

namespace PaymentAPI.Process
{
    public class PaymentHistory : IPaymentHistory
    {
        private CPGContext _CPGContext;

        public PaymentHistory(CPGContext cPGContext)
        {
            _CPGContext = cPGContext;
        }

        public PaymentResponse GetPaymentRequest(int merchantId, int paymentId)
        {
            if (!_CPGContext.PaymentRequests.Any(x => x.PaymentRequestId == paymentId && x.MerchantId == merchantId))
                return null;

            var paymentRequestDetails = _CPGContext.PaymentRequests.First(x => x.PaymentRequestId == paymentId && x.MerchantId == merchantId);

            var cardDetails = _CPGContext.Cards.First(x => x.CardId == paymentRequestDetails.CardId);


            var cardNumberArray = cardDetails.card_number.ToCharArray();

            for (int i = 0; i < cardNumberArray.Length - 4; i++)
            {
                cardNumberArray[i] = '*';
            }

           string maskedCardNo = String.Join("", cardNumberArray);


            return new PaymentResponse() {
                paymentRequestId = paymentRequestDetails.PaymentRequestId,
                card_number = maskedCardNo,
                currency = paymentRequestDetails.currency,
                amount = paymentRequestDetails.amount,
                Status = paymentRequestDetails.status == true ? "Success" : "Unsuccesfull"
                };
        }
    }
}
