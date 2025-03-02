using Bookmarted.Application.DTOs;
using Bookmarted.Application.Interfaces;

namespace Bookmarted.Application.Services
{
    public class BookService : IBookService
    {
        public Task<IEnumerable<BookDto>> GetAllBooksAsync() => throw new NotImplementedException();
        public Task<BookDto> GetBookByIdAsync(int bookId) => throw new NotImplementedException();
        public Task<BookDto> CreateBookAsync(CreateBookDto bookDto) => throw new NotImplementedException();
        public Task<bool> UpdateBookAsync(int bookId, UpdateBookDto bookDto) => throw new NotImplementedException();
        public Task<bool> DeleteBookAsync(int bookId) => throw new NotImplementedException();
    }
}
