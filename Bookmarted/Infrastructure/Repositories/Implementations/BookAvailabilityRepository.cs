using Bookmarted.Domain.Entities;
using Bookmarted.Infrastructure.Persistence;
using Bookmarted.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Bookmarted.Infrastructure.Repositories.Implementations
{
    public class BookAvailabilityRepository : IBookAvailabilityRepository
    {
        private readonly BookStoreDbContext _context;

        public BookAvailabilityRepository(BookStoreDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<BookAvailability>> GetByStoreIdAsync(int storeId) =>
            await _context.BookAvailabilities.Where(ba => ba.StoreId == storeId).ToListAsync();

        public async Task<BookAvailability?> GetByIdAsync(int availabilityId) =>
            await _context.BookAvailabilities.FirstOrDefaultAsync(ba => ba.BookAvailabilityId == availabilityId);

        public async Task<BookAvailability> AddAsync(BookAvailability availability)
        {
            await _context.BookAvailabilities.AddAsync(availability);
            await _context.SaveChangesAsync();
            return availability;
        }

        public async Task<bool> UpdateAsync(BookAvailability availability)
        {
            _context.BookAvailabilities.Update(availability);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteAsync(int availabilityId)
        {
            var availability = await GetByIdAsync(availabilityId);
            if (availability == null) return false;
            _context.BookAvailabilities.Remove(availability);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
