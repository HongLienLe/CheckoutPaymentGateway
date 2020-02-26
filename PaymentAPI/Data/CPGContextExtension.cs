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
        }
    }
}
