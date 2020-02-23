using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PaymentAPI.Models
{
    public class Merchant
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MerchantId { get; set; }

        public string Name { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Min value must be equal 0 or more")]
        public int LowerBound { get; set; }

        [Required]
        public int UpperBound { get; set; }

        public ICollection<PaymentRequest> PaymentRequests { get; set; }
        public ICollection<Customer> Customers { get; set; }
        public ICollection<Card> Cards { get; set; }

        public Merchant()
        {
            PaymentRequests = new List<PaymentRequest>();
            Customers = new List<Customer>();
            Cards = new List<Card>();
        }

    }
}
