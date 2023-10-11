using Microsoft.EntityFrameworkCore;
using PancakeApp.Domain.Models;

namespace PancakeApp.DataAccess.DataContext
{
    public class PancakeAppDbContext : DbContext
    {
        public PancakeAppDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions) 
        { 
        
        }
        
        public DbSet<Pancake> Pancakes { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Location> Locations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Pancake>()
                .HasMany(x => x.PancakeOrders)
                .WithOne(x => x.Pancake)
                .HasForeignKey(x => x.PancakeId);

            modelBuilder.Entity<Order>()
                .HasMany(x => x.PancakeOrders)
                .WithOne(x => x.Order)
                .HasForeignKey(x => x.OrderId);

            modelBuilder.Entity<Location>()
                .HasMany(x => x.Orders)
                .WithOne(x => x.Location)
                .HasForeignKey(x => x.LocationId);

        }


    }
}
