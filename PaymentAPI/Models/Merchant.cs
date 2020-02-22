using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PaymentAPI.Models
{
    public class Merchant
    {
        [Key]
        public int MerchantId { get; set; }
        public string name { get; set; }

        public ICollection<PaymentRequest> PaymentRequests { get; set; }
        public ICollection<Customer> Customers { get; set; }

        public Merchant()
        {
            PaymentRequests = new List<PaymentRequest>();
            Customers = new List<Customer>();
        }

    }
}
