using System;
using Microsoft.EntityFrameworkCore;

namespace PaymentAPI.Models
{
    public interface ICPGContext : IDisposable
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<PaymentRequest> PaymentRequests { get; set; }
        public DbSet<Card> Cards { get; set; }
        public DbSet<Merchant> Merchants { get; set; }
        int SaveChanges();
        void MarkAsModified(object item);
    }
}
