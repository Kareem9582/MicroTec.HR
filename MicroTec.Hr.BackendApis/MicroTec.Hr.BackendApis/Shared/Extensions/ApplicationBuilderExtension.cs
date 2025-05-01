using Microsoft.AspNetCore.HttpOverrides;

namespace MicroTec.Hr.BackendApi.Shared.Extensions
{
    public static class ApplicationBuilderExtension
    {
        public static WebApplication SetupApplicationBuilder(this WebApplication app)
        {
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
            });
            app.UseCors("AllowFrontend");
            app.MapHealthChecks("/health");
            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();
            app.MapControllers();

            return app;
        }
    }
}
