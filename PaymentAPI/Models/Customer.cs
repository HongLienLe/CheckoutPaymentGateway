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
        public int CustomerId { get; set; }

        [Required]
        public string email { get; set; }

        [Required]
        public string name { get; set; }

        public int CardId { get; set; }
        public Card Card { get; set; }

        public int MerchantId { get; set; }
        public Merchant Merchant { get; set; }

        public ICollection<PaymentRequest> PaymentRequest { get; set; }

        public Customer()
        {
            PaymentRequest = new List<PaymentRequest>();
        }

    }
}
