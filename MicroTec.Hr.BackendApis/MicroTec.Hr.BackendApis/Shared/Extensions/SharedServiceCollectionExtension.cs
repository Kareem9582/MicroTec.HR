using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;

namespace MicroTec.Hr.BackendApi.Shared.Extensions
{
    public static class SharedServiceCollectionExtension
    {
        public static IServiceCollection SetupApplicationSharedServices(this IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddControllers()
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                });
            services.AddApiVersioning(options =>
            {
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.DefaultApiVersion = new ApiVersion(1, 0);
                options.ReportApiVersions = true;
            });
            var origins = configuration.GetSection("Cors:AllowedOrigins").Get<string[]>() ?? [];
            services.AddCors(options =>
            {
                options.AddPolicy("AllowFrontend",
                    policy => policy.WithOrigins(origins)
                                    .AllowAnyHeader()
                                    .AllowAnyMethod());
            });

            services.AddMediatR(cfg =>
                cfg.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()));
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddValidation();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            return services;
        }
    }
}
