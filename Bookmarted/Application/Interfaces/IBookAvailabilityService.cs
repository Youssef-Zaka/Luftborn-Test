using Bookmarted.Application.DTOs;

namespace Bookmarted.Application.Interfaces
{
    public interface IBookAvailabilityService
    {
        Task<IEnumerable<BookAvailabilityDto>> GetBooksByStoreAsync(int storeId);
        Task<BookAvailabilityDto> CreateBookAvailabilityAsync(CreateBookAvailabilityDto availabilityDto);
        Task<bool> UpdateBookAvailabilityAsync(int availabilityId, UpdateBookAvailabilityDto availabilityDto);
        Task<bool> DeleteBookAvailabilityAsync(int availabilityId);
    }
}
