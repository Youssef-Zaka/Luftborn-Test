using Bookmarted.Application.DTOs;
using Bookmarted.Application.Interfaces;

namespace Bookmarted.Application.Services
{
    public class StoreService : IStoreService
    {
        public Task<IEnumerable<StoreDto>> GetAllStoresAsync() => throw new NotImplementedException();
        public Task<StoreDto> GetStoreByIdAsync(int storeId) => throw new NotImplementedException();
        public Task<StoreDto> CreateStoreAsync(CreateStoreDto storeDto) => throw new NotImplementedException();
        public Task<bool> UpdateStoreAsync(int storeId, UpdateStoreDto storeDto) => throw new NotImplementedException();
        public Task<bool> DeleteStoreAsync(int storeId) => throw new NotImplementedException();
    }
}
