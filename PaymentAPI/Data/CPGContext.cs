using System;
using Microsoft.EntityFrameworkCore;
using PaymentAPI.Models;

namespace PaymentAPI.Data
{
    public partial class CPGContext : DbContext
    {
        public CPGContext(DbContextOptions<CPGContext> options) : base(options)
        {
          //  Database.EnsureCreated();
        }

        public virtual DbSet<Card> Cards { get; set; }
        public virtual DbSet<Merchant> Merchants { get; set; }
        public virtual DbSet<PaymentRequest> PaymentRequests { get; set; }
        public virtual DbSet<BankPaymentResponse> BankPaymentResponses { get; set; }
    }
}
