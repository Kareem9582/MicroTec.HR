using Microsoft.Extensions.DependencyInjection;
using MicroTec.Hr.Domain.Contract;
using MicroTec.Hr.Infrastructure.Extensions;
using MicroTec.Hr.Infrastructure.Shared;

namespace MicroTec.Hr.Services.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationBusinessServices(this IServiceCollection services, string connectionString)
        {
            // Use the DbContext extension method from the Infrastructure Layer
            services.AddApplicationDbContext(connectionString);
            services.AddScoped<IDomainEventDispatcher, DomainEventDispatcher>();
            // Register other services in the Application Layer
            services.AddCors(options =>
            {
                options.AddPolicy("AllowFrontend",
                    policy => policy.WithOrigins("http://localhost:4200")
                                    .AllowAnyHeader()
                                    .AllowAnyMethod());
            });

            return services;
        }
    }
}
