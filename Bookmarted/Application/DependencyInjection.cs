using Bookmarted.Application.Interfaces;
using Bookmarted.Application.Services;

namespace Bookmarted.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IBookService, BookService>();
            services.AddScoped<IStoreService, StoreService>();
            services.AddScoped<IBookAvailabilityService, BookAvailabilityService>();

            return services;
        }
    }
}
