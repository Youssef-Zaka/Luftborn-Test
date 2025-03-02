using Bookmarted.Domain.Entities;

namespace Bookmarted.Infrastructure.Repositories.Interfaces
{
    public interface IBookAvailabilityRepository
    {
        Task<IEnumerable<BookAvailability>> GetByStoreIdAsync(int storeId);
        Task<BookAvailability?> GetByIdAsync(int availabilityId);
        Task<BookAvailability> AddAsync(BookAvailability availability);
        Task<bool> UpdateAsync(BookAvailability availability);
        Task<bool> DeleteAsync(int availabilityId);
    }
}
