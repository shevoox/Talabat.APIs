using Talabat.APIs.Helpers;
using Talabat.Core.Repositories;
using Talabat.Infrastructure.Repository;
using Talabat.Repository;

namespace Talabat.APIs.Extensions
{
    public static class ApplicationServiceExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {

            services.AddScoped(typeof(IGenaricRepository<>), typeof(GenaricRepository<>));
            services.AddScoped(typeof(IBasketRepository), typeof(BasketRepository));

            //builder.Services.AddAutoMapper(M => M.AddProfile(new MappingProfiles()));
            services.AddAutoMapper(typeof(MappingProfiles));
            return services;
        }
    }
}
