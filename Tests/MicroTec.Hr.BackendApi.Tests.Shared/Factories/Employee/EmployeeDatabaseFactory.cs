using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using MicroTec.Hr.BackendApi.Tests.Shared.Helpers;

namespace MicroTec.Hr.BackendApi.Tests.Shared.Factories.Employee
{
    public class EmployeeDatabaseFactory : WebApplicationFactory<Program>
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureTestServices(services => // ← Use ConfigureTestServices instead
            {
                TestDbConfigurator.ConfigureTestDbContext(services);
            });
        }
    }
}
