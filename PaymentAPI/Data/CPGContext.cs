﻿using System;
using Microsoft.EntityFrameworkCore;
using PaymentAPI.Models;

namespace PaymentAPI.Data
{
    public class CPGContext : DbContext
    {
        public CPGContext(DbContextOptions<CPGContext> options) : base(options)
        {
            Database.EnsureDeleted();
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<PaymentRequest> PaymentRequests { get; set; }
        public DbSet<Card> Cards { get; set; }
        public DbSet<Merchant> Merchants { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>(e =>
            {
                e.HasOne(x => x.Card)
                .WithOne(x => x.Customer)
                .HasForeignKey<Card>(x => x.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);

                e.HasMany(x => x.PaymentRequest)
                .WithOne(x => x.Customer)
                .HasForeignKey(x => x.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);

                e.HasOne(x => x.Merchant)
                .WithMany(x => x.Customers)
                .HasForeignKey(x => x.MerchantId)
                .OnDelete(DeleteBehavior.Restrict);
            });

        }
    }
}
