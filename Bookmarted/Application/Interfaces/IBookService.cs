using Bookmarted.Application.DTOs;

namespace Bookmarted.Application.Interfaces
{
    public interface IBookService
    {
        Task<IEnumerable<BookDto>> GetAllBooksAsync();
        Task<BookDto> GetBookByIdAsync(int bookId);
        Task<BookDto> CreateBookAsync(CreateBookDto bookDto);
        Task<bool> UpdateBookAsync(int bookId, UpdateBookDto bookDto);
        Task<bool> DeleteBookAsync(int bookId);
    }

}
