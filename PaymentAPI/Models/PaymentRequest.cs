using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace PaymentAPI.Models
{
    public class PaymentRequest
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PaymentRequestId { get; private set; }

        [Range(0,Double.MaxValue, ErrorMessage = "Amount value must ")]
        public int amount { get; private set; }

        [Required]
        [StringLength(3, ErrorMessage = "Currency must have 3 Characters",MinimumLength = 3)]
        public string currency { get; private set; }

        [Required]
        public DateTime capture_on { get; private set; }

        [Required]
        public PaymentType payment_type { get; private set; }

        public string description { get; set; }

        [Required]
        public int CustomerId { get; set; }
        public Customer Customer { get; private set; }

        [Required]
        public int CardId { get; set; }
        public Card Card { get; private set; }

        [Required]
        public int MerchantId { get; set; }
        public Merchant Merchant { get; private set; }

        private PaymentRequest()
        {

        }

        public PaymentRequest(int amount, string currency, PaymentType paymentType, int customerId, int merchantId, Card card)
        {
            this.amount = amount;
            this.currency = currency;
            payment_type = paymentType;
            CustomerId = customerId;
            MerchantId = merchantId;
            Card = card;
            capture_on = DateTime.UtcNow;
        }

    }

    public enum PaymentType
    {
        OneOff,
        Recurring
    }
}
