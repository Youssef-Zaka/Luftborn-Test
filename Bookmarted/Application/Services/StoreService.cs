using Bookmarted.Application.DTOs;
using Bookmarted.Application.Interfaces;
using Bookmarted.Domain.Entities;
using Bookmarted.Infrastructure.Repositories.Interfaces;

namespace Bookmarted.Application.Services
{
    public class StoreService : IStoreService
    {
        private readonly IStoreRepository _storeRepository;

        public StoreService(IStoreRepository storeRepository)
        {
            _storeRepository = storeRepository;
        }

        public async Task<IEnumerable<StoreDto>> GetAllStoresAsync()
        {
            var stores = await _storeRepository.GetAllAsync();
            return stores.Select(s => new StoreDto(s.StoreId, s.Name));
        }

        public async Task<StoreDto?> GetStoreByIdAsync(int storeId)
        {
            var store = await _storeRepository.GetByIdAsync(storeId);
            if (store == null) return null;
            return new StoreDto(store.StoreId, store.Name);
        }

        public async Task<StoreDto> CreateStoreAsync(CreateStoreDto storeDto)
        {
            var store = new Store { Name = storeDto.Name };
            var createdStore = await _storeRepository.AddAsync(store);
            return new StoreDto(createdStore.StoreId, createdStore.Name);
        }

        public async Task<bool> UpdateStoreAsync(int storeId, UpdateStoreDto storeDto)
        {
            var store = await _storeRepository.GetByIdAsync(storeId);
            if (store == null) return false;
            store.Name = storeDto.Name;
            return await _storeRepository.UpdateAsync(store);
        }

        public async Task<bool> DeleteStoreAsync(int storeId)
        {
            return await _storeRepository.DeleteAsync(storeId);
        }
    }
}
