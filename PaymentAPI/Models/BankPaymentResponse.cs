using System;
namespace PaymentAPI.Models
{
    public sealed class BankPaymentResponse
    {
        public Guid Id { get; set; }
        public bool Status { get; set; }

        public int PaymentRequestId { get; set; }
        public PaymentRequest PaymentRequest { get; set; }

        public BankPaymentResponse(Guid id, bool status)
        {
            Id = id;
            Status = status;
        }
    }
}
