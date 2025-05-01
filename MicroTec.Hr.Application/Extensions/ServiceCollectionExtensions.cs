using Microsoft.Extensions.DependencyInjection;
using MicroTec.Hr.Infrastructure.Extensions;

namespace MicroTec.Hr.Application.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, string connectionString)
        {
            // Use the DbContext extension method from the Infrastructure Layer
            services.AddApplicationDbContext(connectionString);

            // Register other services in the Application Layer
            //services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            //services.AddScoped<IEmployeeService, EmployeeService>();

            return services;
        }
    }
}
