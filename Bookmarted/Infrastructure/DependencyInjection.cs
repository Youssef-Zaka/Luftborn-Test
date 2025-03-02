using Bookmarted.Infrastructure.Persistence;
using Bookmarted.Infrastructure.Repositories.Implementations;
using Bookmarted.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Bookmarted.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<BookStoreDbContext>(options =>
                options.UseSqlServer(connectionString));

            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<IStoreRepository, StoreRepository>();
            services.AddScoped<IBookAvailabilityRepository, BookAvailabilityRepository>();

            return services;
        }
    }
}
