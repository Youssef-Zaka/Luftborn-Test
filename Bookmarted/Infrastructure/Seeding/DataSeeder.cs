using Bookmarted.Domain.Entities;
using Bookmarted.Domain.Enums;
using Bookmarted.Domain.ValueObjects;
using Bookmarted.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Bookmarted.Infrastructure.Seeding
{
    public class DataSeeder
    {
        private readonly BookStoreDbContext _context;

        public DataSeeder(BookStoreDbContext context)
        {
            _context = context;
        }

        public async Task SeedAsync()
        {
            await _context.Database.MigrateAsync(); // Apply pending migrations

            // Reset identity counters and clear tables
            await _context.Database.ExecuteSqlRawAsync("DELETE FROM BookAvailabilities");
            await _context.Database.ExecuteSqlRawAsync("DELETE FROM Books");
            await _context.Database.ExecuteSqlRawAsync("DELETE FROM Stores");

            await _context.Database.ExecuteSqlRawAsync("DBCC CHECKIDENT ('Stores', RESEED, 0)");
            await _context.Database.ExecuteSqlRawAsync("DBCC CHECKIDENT ('Books', RESEED, 0)");
            await _context.Database.ExecuteSqlRawAsync("DBCC CHECKIDENT ('BookAvailabilities', RESEED, 0)");


            if (!_context.Stores.Any())
            {
                await SeedStores();
                await SeedBooks();
                // Save changes to ensure Books and Stores are available in the database
                await _context.SaveChangesAsync();

                await SeedBookAvailabilities();
                await _context.SaveChangesAsync();
            }
        }

        private async Task SeedStores()
        {
            var stores = new List<Store>
            {
                new Store { Name = "Downtown Bookstore" },
                new Store { Name = "City Library Shop" },
                new Store { Name = "Readers Haven" },
                new Store { Name = "The Book Loft" },
                new Store { Name = "Paperback Palace" }
            };
            await _context.Stores.AddRangeAsync(stores);
        }

        private async Task SeedBooks()
        {
            var books = new List<Book>
            {
                new Book { Title = "The Great Gatsby", Description = "A novel by F. Scott Fitzgerald", Genre = Genre.Fiction, Condition = BookCondition.New },
                new Book { Title = "To Kill a Mockingbird", Description = "A novel by Harper Lee", Genre = Genre.Fiction, Condition = BookCondition.Used },
                new Book { Title = "1984", Description = "A dystopian novel by George Orwell", Genre = Genre.Science, Condition = BookCondition.New },
                new Book { Title = "The Catcher in the Rye", Description = "A classic by J.D. Salinger", Genre = Genre.Mystery, Condition = BookCondition.Used },
                new Book { Title = "Pride and Prejudice", Description = "A novel by Jane Austen", Genre = Genre.Fiction, Condition = BookCondition.New },
                new Book { Title = "The Hobbit", Description = "A fantasy novel by J.R.R. Tolkien", Genre = Genre.Fantasy, Condition = BookCondition.Used },
                new Book { Title = "Steve Jobs", Description = "A biography by Walter Isaacson", Genre = Genre.Biography, Condition = BookCondition.New },
                new Book { Title = "A Brief History of Time", Description = "Science book by Stephen Hawking", Genre = Genre.Science, Condition = BookCondition.Damaged },
                new Book { Title = "Sapiens", Description = "A brief history of humankind by Yuval Noah Harari", Genre = Genre.History, Condition = BookCondition.New },
                new Book { Title = "The Road", Description = "A post-apocalyptic novel by Cormac McCarthy", Genre = Genre.Others, Condition = BookCondition.Used }
            };
            await _context.Books.AddRangeAsync(books);
        }

        private async Task SeedBookAvailabilities()
        {
            var stores = _context.Stores.ToList();
            var books = _context.Books.ToList();

            var bookAvailabilities = new List<BookAvailability>
    {
        new BookAvailability
        {
            StoreId = 1,
            Store = stores.FirstOrDefault(s => s.StoreId == 1)!,
            BookId = 1,
            Book = books.FirstOrDefault(b => b.BookId == 1)!,
            Price = new Money(19.99m, "EGP"),
            Stock = new Stock(10)
        },
        new BookAvailability
        {
            StoreId = 1,
            Store = stores.FirstOrDefault(s => s.StoreId == 1)!,
            BookId = 2,
            Book = books.FirstOrDefault(b => b.BookId == 2)!,
            Price = new Money(9.99m, "EGP"),
            Stock = new Stock(5)
        },
        new BookAvailability
        {
            StoreId = 1,
            Store = stores.FirstOrDefault(s => s.StoreId == 1)!,
            BookId = 3,
            Book = books.FirstOrDefault(b => b.BookId == 3)!,
            Price = new Money(14.99m, "EGP"),
            Stock = new Stock(7)
        },
        new BookAvailability
        {
            StoreId = 1,
            Store = stores.FirstOrDefault(s => s.StoreId == 1)!,
            BookId = 4,
            Book = books.FirstOrDefault(b => b.BookId == 4)!,
            Price = new Money(12.49m, "EGP"),
            Stock = new Stock(12)
        },
        new BookAvailability
        {
            StoreId = 1,
            Store = stores.FirstOrDefault(s => s.StoreId == 1)!,
            BookId = 5,
            Book = books.FirstOrDefault(b => b.BookId == 5)!,
            Price = new Money(11.99m, "EGP"),
            Stock = new Stock(20)
        },
        new BookAvailability
        {
            StoreId = 2,
            Store = stores.FirstOrDefault(s => s.StoreId == 2)!,
            BookId = 6,
            Book = books.FirstOrDefault(b => b.BookId == 6)!,
            Price = new Money(8.99m, "EGP"),
            Stock = new Stock(6)
        },
        new BookAvailability
        {
            StoreId = 2,
            Store = stores.FirstOrDefault(s => s.StoreId == 2)!,
            BookId = 7,
            Book = books.FirstOrDefault(b => b.BookId == 7)!,
            Price = new Money(15.99m, "EGP"),
            Stock = new Stock(8)
        },
        new BookAvailability
        {
            StoreId = 3,
            Store = stores.FirstOrDefault(s => s.StoreId == 3)!,
            BookId = 8,
            Book = books.FirstOrDefault(b => b.BookId == 8)!,
            Price = new Money(18.49m, "EGP"),
            Stock = new Stock(4)
        },
        new BookAvailability
        {
            StoreId = 4,
            Store = stores.FirstOrDefault(s => s.StoreId == 4)!,
            BookId = 9,
            Book = books.FirstOrDefault(b => b.BookId == 9)!,
            Price = new Money(13.99m, "EGP"),
            Stock = new Stock(14)
        },
        new BookAvailability
        {
            StoreId = 5,
            Store = stores.FirstOrDefault(s => s.StoreId == 5)!,
            BookId = 10,
            Book = books.FirstOrDefault(b => b.BookId == 10)!,
            Price = new Money(10.99m, "EGP"),
            Stock = new Stock(9)
        }
    };

            await _context.BookAvailabilities.AddRangeAsync(bookAvailabilities);
        }

    }
}
