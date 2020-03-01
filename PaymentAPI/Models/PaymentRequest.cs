using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace PaymentAPI.Models
{
    public sealed class PaymentRequest
    {
        private int _amount;
        private string _currency;
        private int _merchantId;
        private Card _card;
        private DateTime _capture_on;


        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PaymentRequestId { get; private set; }

        [Range(0, Double.MaxValue, ErrorMessage = "Amount value must ")]
        public int amount { get { return _amount; } set { _amount = value; } }

        [Required]
        [StringLength(3, ErrorMessage = "Currency must have 3 Characters", MinimumLength = 3)]
        public string currency { get { return _currency; } set { _currency = value; } }

        [Required]
        public DateTime capture_on { get{ return _capture_on; } set { _capture_on = value; }  }

        public string description { get; set; }

        public BankPaymentResponse status { get; set; }

        [ForeignKey("Card")]
        public int CardId { get; set; }
        [Required]
        public Card Card { get { return _card; } set { _card = value; } }

        public int MerchantId { get { return _merchantId; } set { _merchantId = value; } }
        public Merchant Merchant { get; private set; }

        private PaymentRequest()
        {

        }

        public PaymentRequest(int amount, string currency, int merchantId, Card card)
        {
            _amount = amount;
            _currency = currency;
            _merchantId = merchantId;
            _card = card;
            _capture_on = DateTime.UtcNow; 
        }

    }
}
