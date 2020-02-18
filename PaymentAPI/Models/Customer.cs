using System;
using System.ComponentModel.DataAnnotations;

namespace PaymentAPI.Models
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }
        public string email { get; set; }
        public string name { get; set; }
    }
}
