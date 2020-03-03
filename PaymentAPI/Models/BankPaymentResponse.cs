using System;
using System.ComponentModel.DataAnnotations;

namespace PaymentAPI.Models
{
    public sealed class BankPaymentResponse
    {
        [Key]
        public int BankPaymentResponseId { get; set; }

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
