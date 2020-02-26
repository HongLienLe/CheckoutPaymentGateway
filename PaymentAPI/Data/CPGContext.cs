using System;
using Microsoft.EntityFrameworkCore;
using PaymentAPI.Models;

namespace PaymentAPI.Data
{
    public class CPGContext : DbContext
    {
        public CPGContext(DbContextOptions<CPGContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Card> Cards { get; set; }
        public DbSet<Merchant> Merchants { get; set; }
        public DbSet<PaymentRequest> PaymentRequests { get; set; }
    }
}
