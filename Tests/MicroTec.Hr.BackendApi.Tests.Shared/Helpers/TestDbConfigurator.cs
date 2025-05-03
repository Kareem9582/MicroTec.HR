using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.DependencyInjection;
using MicroTec.Hr.Infrastructure.Contexts;

namespace MicroTec.Hr.BackendApi.Tests.Shared.Helpers
{
    public static class TestDbConfigurator
    {
        public static void ConfigureTestDbContext(IServiceCollection services)
        {
            // Set breakpoint here - this CAN be debugged
            var descriptors = services
                    .Where(d => d.ServiceType.Name.Contains("DbContext"))
                    .ToList();

            foreach (var descriptor in descriptors)
            {
                services.Remove(descriptor);
            }

            // Add fresh In-Memory DB
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseInMemoryDatabase("TestDb");
                options.ConfigureWarnings(x => x.Ignore(InMemoryEventId.TransactionIgnoredWarning));
            });
        }
    }
}
