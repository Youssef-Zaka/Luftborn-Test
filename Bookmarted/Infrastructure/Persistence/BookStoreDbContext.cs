using Bookmarted.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Bookmarted.Domain.ValueObjects;

namespace Bookmarted.Infrastructure.Persistence
{
    public class BookStoreDbContext : DbContext
    {
        public BookStoreDbContext(DbContextOptions<BookStoreDbContext> options) : base(options) { }

        public DbSet<Book> Books { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<BookAvailability> BookAvailabilities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // BookAvailability Mapping
            modelBuilder.Entity<BookAvailability>()
                .HasOne(ba => ba.Book)
                .WithMany(b => b.BookAvailabilities)
                .HasForeignKey(ba => ba.BookId);

            modelBuilder.Entity<BookAvailability>()
                .HasOne(ba => ba.Store)
                .WithMany(s => s.BookAvailabilities)
                .HasForeignKey(ba => ba.StoreId);

            // Value Objects Configuration
            modelBuilder.Entity<BookAvailability>()
                .OwnsOne(ba => ba.Price, p =>
                {
                    p.Property(m => m.Amount).HasPrecision(18, 2); // 18 digits with 2 decimal places
                });


            modelBuilder.Entity<BookAvailability>()
                .OwnsOne(ba => ba.Stock);
        }
    }
}
