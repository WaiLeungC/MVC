using Microsoft.EntityFrameworkCore;
using MVC.Models;

namespace MVC.Data
{
    public class MVCContext : DbContext
    {
        public MVCContext(DbContextOptions<MVCContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ItemClient>().HasKey(ic => new
            {
                ic.ItemId,
                ic.ClientId
            });

            modelBuilder.Entity<ItemClient>()
                .HasOne(i => i.Item)
                .WithMany(ic => ic.ItemClients)
                .HasForeignKey(i => i.ItemId);

            modelBuilder.Entity<ItemClient>()
                .HasOne(c => c.Client)
                .WithMany(ic => ic.ItemClients)
                .HasForeignKey(c => c.ClientId);

            modelBuilder.Entity<Item>().HasData(
                new Item { Id = 4, Name = "Microphone", Price = 10.0, SerialNumberId = 10 },
                new Item { Id = 6, Name = "Keyboard", Price = 20.0, SerialNumberId = 13 }
            );

            modelBuilder.Entity<SerialNumber>().HasData(
                new SerialNumber { Id = 10, Name = "MIC150", ItemId = 4 },
                new SerialNumber { Id = 13, Name = "TKL10", ItemId = 6 }
            );

            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 21, Name = "Electronics" },
                new Category { Id = 22, Name = "Books" }
            );
        }

        public DbSet<Item> Items { get; set; }
        public DbSet<SerialNumber> SerialNumbers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<ItemClient> ItemClients { get; set; }
    }
}
