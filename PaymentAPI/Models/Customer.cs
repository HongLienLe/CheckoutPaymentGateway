using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PaymentAPI.Models
{
    public class Customer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CustomerId { get; private set; }

        [Required]
        [EmailAddress]
        public string email { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Character Length exceed max of 50")]
        public string name { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Merchant Id must is required and must be a min value 0")]
        public int MerchantId { get; set; }
        public Merchant Merchant { get; set; }

        public ICollection<PaymentRequest> PaymentRequest { get; set; }
        public ICollection<Card> Cards { get; set; }

        private Customer()
        {
            PaymentRequest = new List<PaymentRequest>();
            Cards = new List<Card>();
        }

        public Customer(string email, string name, int merchantId)
        {
            this.email = email;
            this.name = name;
            MerchantId = merchantId;
        }

    }
}
