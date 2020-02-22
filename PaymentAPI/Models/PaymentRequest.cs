﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace PaymentAPI.Models
{
    public class PaymentRequest
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PaymentRequestId { get; set; }

        [Range(0,Double.MaxValue, ErrorMessage = "Amount value must ")]
        public int amount { get; set; }

        [StringLength(3, ErrorMessage = "Currency must have 3 Characters",MinimumLength = 3)]
        public string currency { get; set; }

        [Required]
        public DateTime capture_on { get; set; }

        public PaymentType payment_type { get; set; }
        public string description { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        public int MerchantId { get; set; }
        public Merchant Merchant { get; set; }

    }

    public enum PaymentType
    {
        OneOff,
        Recurring
    }
}
