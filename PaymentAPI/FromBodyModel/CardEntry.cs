using System;
using System.ComponentModel.DataAnnotations;

namespace PaymentAPI.FromBodyModel
{
    public class CardEntry
    {
        [Required]
        public int customerId { get; set; }

        [Required]
        public string cardNumber { get; set; }

        [Required]
        public int merchantId { get; set; }

    }
}
