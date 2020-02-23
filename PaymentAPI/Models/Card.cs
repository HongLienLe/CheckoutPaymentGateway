using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PaymentAPI.Models
{
    public class Card
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CardId { get; set; }

        [StringLength(16, ErrorMessage = "Card number contains of 16 digits")]
        public string card_number { get; set; }

        [Range(1, 12, ErrorMessage = "Must enter the month between 1 - 12")]
        public int expiry_month { get; set; }

        [Range(2020, 2025, ErrorMessage = "Must enter the month between 1 - 12")]
        public string expiry_year { get; set; }

        [StringLength(3, ErrorMessage = "Currency code is contains 3 letters", MinimumLength = 3)]
        public string currency { get; set; }

        [StringLength(3, ErrorMessage = "CVV code is contains 3 letters", MinimumLength = 3)]
        public string cvv { get; set; }

        public string name { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        public PaymentRequest PaymentRequest { get; set; }

    }
}
