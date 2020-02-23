using System;
using System.Linq;
using PaymentAPI.Models;

namespace PaymentAPI.Data
{
    public static class CPGContextExtension
    {
        public static void SeedData(this CPGContext context)
        {
            if (context.Merchants.Any())
                return;

            var merchant = new Merchant()
            {
                Name = "Merchant0",
                UpperBound = 1000,
            };

            context.Merchants.Add(merchant);

            context.SaveChanges();
        }
    }
}
