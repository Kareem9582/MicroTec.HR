using MicroTec.Hr.BackendApi.Shared.Extensions;
using MicroTec.Hr.Services.Extensions;

namespace MicroTec.Hr.BackendApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.SetupApplicationSharedServices(builder.Configuration);

            //Setup Database connection and Business Related Services
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddApplicationBusinessServices(connectionString!);
            builder.AddLoggingToFile();
            var app = builder.Build();

            app.SetupMiddleWare();
            app.SetupApplicationBuilder();

            app.Run();
        }
    }
}
