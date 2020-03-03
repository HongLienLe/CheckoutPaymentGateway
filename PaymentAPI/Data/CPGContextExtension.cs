using System;
using System.Collections.Generic;
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


            List<Merchant> Merchants = new List<Merchant>()
            {
                new Merchant("Merchant 1"){MinAmount = 0, MaxAmount = 1000 },
                new Merchant("Merchant 2"){MinAmount = 200, MaxAmount = 2000 },
                new Merchant("Merchant 3"){MinAmount = 3000, MaxAmount = 30000 }
            };

            context.Merchants.AddRange(Merchants);
            context.SaveChanges();
        }
    }
}
