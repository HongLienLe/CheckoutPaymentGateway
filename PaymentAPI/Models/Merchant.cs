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
        public int MerchantId { get; protected set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "Min value must be equal 0 or more")]
        public int MinAmount { get; set; }

        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "Min value must be equal 0 or more")]
        public int MaxAmount { get; set; }


        public ICollection<PaymentRequest> PaymentRequests { get; set; }
        public ICollection<Card> Cards { get; set; }

        private Merchant()
        {
            Cards = new List<Card>();
            PaymentRequests = new List<PaymentRequest>();

        }

        public Merchant(string name)
        {
            Name = name;
        }

    }
}
