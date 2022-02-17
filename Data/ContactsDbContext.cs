using ContactManager.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManager.Data
{
    public class ContactsDbContext : DbContext
    {
        private readonly IConfiguration _config;

        public ContactsDbContext(IConfiguration config)
        {
            _config = config;
        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Address> Addresses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            base.OnConfiguring(builder);
            builder.UseSqlServer(_config.GetConnectionString("ContactManagerConnectionString"));
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>()
                .Property(c => c.FirstName).IsRequired().HasMaxLength(200);
            modelBuilder.Entity<Client>()
                .Property(c => c.LastName).IsRequired().HasMaxLength(200);

            modelBuilder.Entity<Address>()
                .Property(a => a.FullAddress).IsRequired().HasMaxLength(300);
        }
    }
}
