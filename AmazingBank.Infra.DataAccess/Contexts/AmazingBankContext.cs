using AmazingBank.DomainModel.Entities;
using AmazingBank.DomainModel.ValueObjects;
using AmazingBank.Infra.DataAccess.Contexts.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AmazingBank.Infra.DataAccess.Contexts
{
    public class AmazingBankContext : DbContext
    {
        public DbSet<Client> Clients { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<DbCurrency> Currencies { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<AmountTransaction> AmountTransactions { get; set; }

        public AmazingBankContext()
        {
            //Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer(Properties.Resources.
                ResourceManager.GetString("DbConnectionString"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder
                .Entity<Account>()
                .Property(account => account.Amount)
                .HasConversion(
                    amount => amount.ToString(),
                    amount => Amount.Parse(amount))
                .HasColumnName("Amount");

            modelBuilder
                .Entity<DbCurrency>()
                .Property(dbCurrency => dbCurrency.Currency)
                .HasConversion(
                    currency => currency.ToString(),
                    currency => new Currency(currency))
                .HasColumnName("Currency");

            modelBuilder
                .Entity<AmountTransaction>()
                .Property(transaction => transaction.Amount)
                .HasConversion(
                    amount => amount.ToString(),
                    amount => Amount.Parse(amount))
                .HasColumnName("Amount");

        }
    }
}
