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

            var merchant = context.Merchants.First(x => x.MerchantId == 7);

            context.Entry<Merchant>(merchant).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            
            //var customer = new Customer("MA Customer@email.com", "Customer A");
            //var card = new Card("1234567890123456", 1, 2010, "788", "Customer A", customer);

            //   var paymentRequest = new PaymentRequest(1000, "GBP", PaymentType.OneOff, customer, merchant, card);

            context.SaveChanges();
            //context.Customers.Add(customer);
            //context.SaveChanges();
            //context.Cards.Add(card);
            //context.SaveChanges();
            //context.PaymentRequests.Add(paymentRequest);

            //context.SaveChanges();
        }
    }
}
