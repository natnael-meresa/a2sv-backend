using Application.Persistance.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistance.Repositories;

namespace Persistance
{
    public static class PersistenceServicesRegistration
    {
        public static IServiceCollection ConfigurePersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<BloggingContext>(options =>
            options.UseNpgsql(
                configuration.GetConnectionString("ConnectionString")));
            
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            services.AddScoped<IPostRepository, PostRepository>();

            return services;
        }
    }
}