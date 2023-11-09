using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.EntityFramework
{
    public class ApiRestDbContext: DbContext
    {
        public ApiRestDbContext(DbContextOptions<ApiRestDbContext> options) :base( options)
        {
            
        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Vendor> Vendors { get; set; }
        public DbSet<Sales> Sales { get; set; } 


        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            modelBuilder.Entity<Client>()
                        .ToTable("Client")
                        .HasKey(key=> key.Id);

            modelBuilder.Entity<Vendor>()
                        .ToTable("Vendor")
                        .HasKey(key => key.Id);

            modelBuilder.Entity<Sales>()
                        .ToTable("Sale")
                        .HasKey(key => key.Id);
            modelBuilder.Entity<Sales>()
                        .HasOne(column => column.Client)
                        .WithMany(collection => collection.Sales)
                        .HasForeignKey(colum => colum.ClientId);
            modelBuilder.Entity<Sales>()
                        .HasOne(column => column.Vendor)
                        .WithMany(collection => collection.Sales)
                        .HasForeignKey(colum => colum.VendorId);
        }
    }
}
