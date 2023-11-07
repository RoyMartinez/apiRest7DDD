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


        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            modelBuilder.Entity<Client>()
                        .ToTable("Client")
                        .HasKey(key=> key.Id);

            modelBuilder.Entity<Vendor>()
                        .ToTable("Vendor")
                        .HasKey(key => key.Id);
        }
    }
}
