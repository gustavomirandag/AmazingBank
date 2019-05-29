using AmazingBank.DomainModel.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AmazingBank.Infrastructure.DataAccess.Contexts
{
    public class AmazingBankContext : DbContext
    {
        public DbSet<Client> Clients { get; set; }

        public AmazingBankContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer(Properties.Resources.
                ResourceManager.GetString("DbConnectionString"));
        }
    }
}
