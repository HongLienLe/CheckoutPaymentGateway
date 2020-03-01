using System;
using System.Collections.Generic;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using PaymentAPI.Data;
using PaymentAPI.Models;

namespace PaymentAPITest
{
    public class ConnectionFactory : IDisposable
    {
        public SqliteConnection connection { get; set; }

        private bool disposedValue = false; // To detect redundant calls  

        public CPGContext CreateContextForSQLite()
        {
            connection = new SqliteConnection("DataSource=:CheckoutDB:");

            connection.Open();

            var option = new DbContextOptionsBuilder<CPGContext>().UseSqlite(connection).Options;

            var context = new CPGContext(option);

            if (context != null)
            {
               // context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
                seedDataToInMemoryDB(context);
            }


            return context;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                }

                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }

        public void seedDataToInMemoryDB(CPGContext context)
        {
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
