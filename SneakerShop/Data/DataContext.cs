using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.EntityFrameworkCore;
using SneakerShop.Models;

namespace SneakerShop.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Size> Sizes { get; set; }
        public DbSet<Sneaker> Sneakers { get; set; }
        public DbSet<SneakerSize> SneakerSizes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SneakerSize>()
                .HasKey(ss => new { ss.SneakerId, ss.SizeId });
            modelBuilder.Entity<SneakerSize>()
                .HasOne(s => s.Sneaker)
                .WithMany(ss => ss.SneakerSizes)
                .HasForeignKey(s => s.SneakerId);
            modelBuilder.Entity<SneakerSize>()
                .HasOne(s => s.Size)
                .WithMany(ss => ss.SneakerSizes)
                .HasForeignKey(s => s.SizeId);
        }
    }
}
