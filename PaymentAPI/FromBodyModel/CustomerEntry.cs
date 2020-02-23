using System;
using System.ComponentModel.DataAnnotations;
using PaymentAPI.Models;

namespace PaymentAPI.FromBodyModel
{
    public class CustomerEntry
    {
        [Required]
        public int merchantId { get; set; }

        [Required]
        public string email { get; set; }
    }
}
