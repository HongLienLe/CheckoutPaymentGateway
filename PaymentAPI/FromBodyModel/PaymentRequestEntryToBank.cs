using System;
using System.ComponentModel.DataAnnotations;
using PaymentAPI.Models;

namespace PaymentAPI.FromBodyModel
{
    public class PaymentRequestEntryToBank
    {
        [Required]
        public PaymentRequest paymentRequest { get; set; }

        [Required]
        public Address billing_address { get; set; }

        [Required]
        public Phone phone { get; set; }
    }
}
