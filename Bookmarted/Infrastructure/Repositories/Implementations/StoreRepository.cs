using Bookmarted.Domain.Entities;
using Bookmarted.Infrastructure.Persistence;
using Bookmarted.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Bookmarted.Infrastructure.Repositories.Implementations
{
    public class StoreRepository : IStoreRepository
    {
        private readonly BookStoreDbContext _context;

        public StoreRepository(BookStoreDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Store>> GetAllAsync() => await _context.Stores.ToListAsync();

        public async Task<Store?> GetByIdAsync(int storeId) => await _context.Stores.FirstOrDefaultAsync(s => s.StoreId == storeId);

        public async Task<Store> AddAsync(Store store)
        {
            await _context.Stores.AddAsync(store);
            await _context.SaveChangesAsync();
            return store;
        }

        public async Task<bool> UpdateAsync(Store store)
        {
            _context.Stores.Update(store);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteAsync(int storeId)
        {
            var store = await GetByIdAsync(storeId);
            if (store == null) return false;
            _context.Stores.Remove(store);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
