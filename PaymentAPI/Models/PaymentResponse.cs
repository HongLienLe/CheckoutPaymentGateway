using System;
namespace PaymentAPI.Models
{
    public class PaymentResponse
    {
        public int paymentRequestId { get; set; }
        public string card_number { get; set; }
        public string currency { get; set; }
        public int amount { get; set; }
        public string Status { get; set; }

    }
}
