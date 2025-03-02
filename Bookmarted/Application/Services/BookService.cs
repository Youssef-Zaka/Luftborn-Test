using Bookmarted.Application.DTOs;
using Bookmarted.Application.Interfaces;
using Bookmarted.Domain.Entities;
using Bookmarted.Infrastructure.Repositories.Interfaces;

namespace Bookmarted.Application.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<IEnumerable<BookDto>> GetAllBooksAsync()
        {
            var books = await _bookRepository.GetAllAsync();
            return books.Select(b => new BookDto(b.BookId, b.Title, b.Description, b.Genre.ToString(), b.Condition.ToString()));
        }

        public async Task<BookDto> GetBookByIdAsync(int bookId)
        {
            var book = await _bookRepository.GetByIdAsync(bookId);
            if (book == null) throw new InvalidOperationException($"Book with ID {bookId} not found.");
            return new BookDto(book.BookId, book.Title, book.Description, book.Genre.ToString(), book.Condition.ToString());
        }

        public async Task<BookDto> CreateBookAsync(CreateBookDto bookDto)
        {
            if (!Enum.TryParse<Domain.Enums.Genre>(bookDto.Genre, true, out var genre))
                throw new InvalidOperationException($"Invalid genre value: {bookDto.Genre}.");

            if (!Enum.TryParse<Domain.Enums.BookCondition>(bookDto.Condition, true, out var condition))
                throw new InvalidOperationException($"Invalid book condition value: {bookDto.Condition}.");

            var book = new Book
            {
                Title = bookDto.Title,
                Description = bookDto.Description,
                Genre = genre,
                Condition = condition
            };

            var createdBook = await _bookRepository.AddAsync(book);
            return new BookDto(createdBook.BookId, createdBook.Title, createdBook.Description, createdBook.Genre.ToString(), createdBook.Condition.ToString());
        }

        public async Task<bool> UpdateBookAsync(int bookId, UpdateBookDto bookDto)
        {
            var book = await _bookRepository.GetByIdAsync(bookId);
            if (book == null) return false;

            if (!Enum.TryParse<Domain.Enums.Genre>(bookDto.Genre, true, out var genre))
                throw new InvalidOperationException($"Invalid genre value: {bookDto.Genre}.");

            if (!Enum.TryParse<Domain.Enums.BookCondition>(bookDto.Condition, true, out var condition))
                throw new InvalidOperationException($"Invalid book condition value: {bookDto.Condition}.");

            book.Title = bookDto.Title;
            book.Description = bookDto.Description;
            book.Genre = genre;
            book.Condition = condition;

            return await _bookRepository.UpdateAsync(book);
        }

        public async Task<bool> DeleteBookAsync(int bookId)
        {
            return await _bookRepository.DeleteAsync(bookId);
        }
    }
}