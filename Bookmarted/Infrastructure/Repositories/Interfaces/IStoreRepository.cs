using Bookmarted.Domain.Entities;

namespace Bookmarted.Infrastructure.Repositories.Interfaces
{
    public interface IStoreRepository
    {
        Task<IEnumerable<Store>> GetAllAsync();
        Task<Store?> GetByIdAsync(int storeId);
        Task<Store> AddAsync(Store store);
        Task<bool> UpdateAsync(Store store);
        Task<bool> DeleteAsync(int storeId);
    }
}
