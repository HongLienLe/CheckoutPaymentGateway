using System;
namespace PaymentAPI.Models
{
    public class Address
    {
        public string address_line1 { get; set; }
        public string address_line2 { get; set; }
        public string city { get; set; }
        public string zip { get; set; }
        public string country { get; set; }
    }
}
