using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PaymentAPI.Models
{
    public sealed class Card
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CardId { get; private set; }

        private string _cardNumber;
        private int _expiryMonth;
        private int _expiryYear;
        private string _currency;
        private string _cvv;
        private string _name;


        [Required]
        [StringLength(16, ErrorMessage = "Card number contains of 16 digits", MinimumLength = 16)]
        public string card_number { get { return _cardNumber; } set { _cardNumber = value; } }

        [Required]
        [Range(1, 12, ErrorMessage = "Must enter the month between 1 - 12")]
        public int expiry_month { get { return _expiryMonth; } set { _expiryMonth = value; } }

        [Required]
        [Range(2020, 2025, ErrorMessage = "Must enter the month between 1 - 12")]
        public int expiry_year { get { return _expiryYear; } set { _expiryYear = value; } }

        [StringLength(3, ErrorMessage = "Currency code is contains 3 letters", MinimumLength = 3)]
        public string currency { get { return _currency; } set { _currency = value; } }

        [Required]
        [StringLength(3, ErrorMessage = "CVV code is contains 3 letters", MinimumLength = 3)]
        public string cvv { get { return _cvv; } set { _cvv = value; } }

        public string name { get { return _name; } set { _name = value; } }

        public Merchant Merchant { get; set; }

        public PaymentRequest PaymentRequest { get; set; }

        private Card()
        {

        }

        public Card(string cardNumber, int expiryMonth, int expiryYear, string cvv, string name)
        {
            _cardNumber = cardNumber;
            _expiryMonth = expiryMonth;
            _expiryYear = expiryYear;
            _cvv = cvv;
            _name = name;
        }

    }
}
