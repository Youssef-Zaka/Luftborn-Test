using Bookmarted.Application.DTOs;
using Bookmarted.Application.Interfaces;

namespace Bookmarted.Application.Services
{
    public class BookAvailabilityService : IBookAvailabilityService
    {
        public Task<IEnumerable<BookAvailabilityDto>> GetBooksByStoreAsync(int storeId) => throw new NotImplementedException();
        public Task<BookAvailabilityDto> CreateBookAvailabilityAsync(CreateBookAvailabilityDto availabilityDto) => throw new NotImplementedException();
        public Task<bool> UpdateBookAvailabilityAsync(int availabilityId, UpdateBookAvailabilityDto availabilityDto) => throw new NotImplementedException();
        public Task<bool> DeleteBookAvailabilityAsync(int availabilityId) => throw new NotImplementedException();
    }
}
