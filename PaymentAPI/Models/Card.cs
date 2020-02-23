using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PaymentAPI.Models
{
    public class Card
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CardId { get; private set; }

        [Required]
        [StringLength(16, ErrorMessage = "Card number contains of 16 digits")]
        public string card_number { get; private set; }

        [Required]
        [Range(1, 12, ErrorMessage = "Must enter the month between 1 - 12")]
        public int expiry_month { get; private set; }

        [Required]
        [Range(2020, 2025, ErrorMessage = "Must enter the month between 1 - 12")]
        public int expiry_year { get; private set; }

        [StringLength(3, ErrorMessage = "Currency code is contains 3 letters", MinimumLength = 3)]
        public string currency { get; set; }

        [Required]
        [StringLength(3, ErrorMessage = "CVV code is contains 3 letters", MinimumLength = 3)]
        public string cvv { get; private set; }

        public string name { get; private set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        public Merchant Merchant { get; set; }

        public PaymentRequest PaymentRequest { get; set; }

        private Card()
        {

        }

        public Card(string card_number, int expiry_month, int expiry_year, string cvv, string name, Customer customer, Merchant merchant)
        {
            this.card_number = card_number;
            this.expiry_month = expiry_month;
            this.expiry_year = expiry_year;
            this.cvv = cvv;
            this.name = name;
            Customer = customer;
            Merchant = merchant;
        }

    }
}
