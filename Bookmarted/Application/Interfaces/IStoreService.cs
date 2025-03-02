using Bookmarted.Application.DTOs;

namespace Bookmarted.Application.Interfaces
{
    public interface IStoreService
    {
        Task<IEnumerable<StoreDto>> GetAllStoresAsync();
        Task<StoreDto> GetStoreByIdAsync(int storeId);
        Task<StoreDto> CreateStoreAsync(CreateStoreDto storeDto);
        Task<bool> UpdateStoreAsync(int storeId, UpdateStoreDto storeDto);
        Task<bool> DeleteStoreAsync(int storeId);
    }
}
