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

        private string _card_number;
        private int _expiry_month;
        private int _expiry_year;
        private string _currency;
        private string _cvv;
        private int _customerId;
        private string _name;
        private int _merchantId;

        [Required]
        [StringLength(16, ErrorMessage = "Card number contains of 16 digits")]
        public string card_number { get { return _card_number; } set { _card_number = value; } }

        [Required]
        [Range(1, 12, ErrorMessage = "Must enter the month between 1 - 12")]
        public int expiry_month { get { return _expiry_month; } set { _expiry_month = value; } }

        [Required]
        [Range(2020, 2025, ErrorMessage = "Must enter the month between 2020 - 2025")]
        public int expiry_year { get { return _expiry_year; } set { _expiry_year = value; } }

        [StringLength(3, ErrorMessage = "Currency code is contains 3 letters", MinimumLength = 3)]
        public string currency { get { return _currency; } set { _currency = value; } }

        [Required]
        [StringLength(3, ErrorMessage = "CVV code is contains 3 Characters", MinimumLength = 3)]
        public string cvv { get { return _cvv; } set { _cvv = value; } }

        [Required]
        [StringLength(1, ErrorMessage = "Name must have at least one character")]
        public string name { get { return _name; } set { _name = value; } }

        [Required]
        [Range(0,int.MaxValue, ErrorMessage ="Customer Id must is required and must be a min value 0")]
        public int CustomerId { get { return _customerId; } set { _customerId = value; } }
        public Customer Customer { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Merchant Id must is required and must be a min value 0")]
        public int MerchantId { get { return _merchantId; } set { _merchantId = value; } }
        public Merchant Merchant { get; set; }

        public PaymentRequest PaymentRequest { get; set; }

        private Card()
        {

        }


        public Card(string card_number, int expiry_month, int expiry_year, string cvv, string name, int customerId, int merchantId)
        {
            _card_number = card_number;
            _expiry_month = expiry_month;
            _expiry_year = expiry_year;
            _cvv = cvv;
            _name = name;
            _customerId= customerId;
            _merchantId = merchantId;
        }

    }
}
