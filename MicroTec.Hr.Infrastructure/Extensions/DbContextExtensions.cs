using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MicroTec.Hr.Domain.Contract;
using MicroTec.Hr.Infrastructure.Contexts;
using MicroTec.Hr.Infrastructure.Employees;
using MicroTec.Hr.Infrastructure.Shared;

namespace MicroTec.Hr.Infrastructure.Extensions
{
    public static class DbContextExtensions
    {
        public static IServiceCollection AddApplicationDbContext(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString));
            
            services.AddHealthChecks()
               .AddSqlServer(connectionString);

            services.AddTransient<IUnitOfWork, UnitOfWork>();

            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(typeof(EmployeeCreatedEventHandler).Assembly);
            });

            return services;
        }
    }
}
