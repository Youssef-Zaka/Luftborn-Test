using Bookmarted.Application.DTOs;
using Bookmarted.Application.Interfaces;
using Bookmarted.Domain.Entities;
using Bookmarted.Domain.ValueObjects;
using Bookmarted.Infrastructure.Repositories.Interfaces;

namespace Bookmarted.Application.Services
{
    public class BookAvailabilityService : IBookAvailabilityService
    {
        private readonly IBookAvailabilityRepository _bookAvailabilityRepository;
        private readonly IStoreRepository _storeRepository;
        private readonly IBookRepository _bookRepository;

        public BookAvailabilityService(IBookAvailabilityRepository bookAvailabilityRepository, IStoreRepository storeRepository, IBookRepository bookRepository)
        {
            _bookAvailabilityRepository = bookAvailabilityRepository;
            _storeRepository = storeRepository;
            _bookRepository = bookRepository;
        }

        public async Task<IEnumerable<BookAvailabilityDto?>> GetBooksByStoreAsync(int storeId)
        {
            var availabilities = await _bookAvailabilityRepository.GetByStoreIdAsync(storeId);
            if (!availabilities.Any())
                throw new InvalidOperationException($"No book availabilities found for store with ID {storeId}.");
            return availabilities.Select(ba => new BookAvailabilityDto(ba.BookAvailabilityId, ba.StoreId, ba.BookId, ba.Price.Amount, ba.Stock.Quantity));
        }

        public async Task<BookAvailabilityDto> CreateBookAvailabilityAsync(CreateBookAvailabilityDto availabilityDto)
        {
            var store = await _storeRepository.GetByIdAsync(availabilityDto.StoreId);
            if (store == null) throw new InvalidOperationException($"Store with ID {availabilityDto.StoreId} not found.");

            var book = await _bookRepository.GetByIdAsync(availabilityDto.BookId);
            if (book == null) throw new InvalidOperationException($"Book with ID {availabilityDto.BookId} not found.");

            var availability = new BookAvailability
            {
                StoreId = availabilityDto.StoreId,
                Store = store,
                BookId = availabilityDto.BookId,
                Book = book,
                Price = new Money(availabilityDto.Price),
                Stock = new Stock(availabilityDto.Stock)
            };

            var createdAvailability = await _bookAvailabilityRepository.AddAsync(availability);
            return new BookAvailabilityDto(createdAvailability.BookAvailabilityId, createdAvailability.StoreId, createdAvailability.BookId, createdAvailability.Price.Amount, createdAvailability.Stock.Quantity);
        }

        public async Task<bool> UpdateBookAvailabilityAsync(int availabilityId, UpdateBookAvailabilityDto availabilityDto)
        {
            var availability = await _bookAvailabilityRepository.GetByIdAsync(availabilityId);
            if (availability == null) return false;

            availability.Price = new Money(availabilityDto.Price);
            availability.Stock = new Stock(availabilityDto.Stock);
            return await _bookAvailabilityRepository.UpdateAsync(availability);
        }

        public async Task<bool> DeleteBookAvailabilityAsync(int availabilityId)
        {
            return await _bookAvailabilityRepository.DeleteAsync(availabilityId);
        }
    }

}
