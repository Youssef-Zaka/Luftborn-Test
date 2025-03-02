using Bookmarted.Domain.Entities;
using Bookmarted.Infrastructure.Persistence;
using Bookmarted.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Bookmarted.Infrastructure.Repositories.Implementations
{
    public class BookRepository : IBookRepository
    {
        private readonly BookStoreDbContext _context;

        public BookRepository(BookStoreDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Book>> GetAllAsync() => await _context.Books.ToListAsync();

        public async Task<Book?> GetByIdAsync(int bookId) => await _context.Books.FirstOrDefaultAsync(b => b.BookId == bookId);

        public async Task<Book> AddAsync(Book book)
        {
            await _context.Books.AddAsync(book);
            await _context.SaveChangesAsync();
            return book;
        }

        public async Task<bool> UpdateAsync(Book book)
        {
            _context.Books.Update(book);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteAsync(int bookId)
        {
            var book = await GetByIdAsync(bookId);
            if (book == null) return false;
            _context.Books.Remove(book);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
