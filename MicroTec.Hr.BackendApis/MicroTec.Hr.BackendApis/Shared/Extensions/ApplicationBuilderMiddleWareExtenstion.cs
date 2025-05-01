using MicroTec.Hr.BackendApi.Shared.Middleware;

namespace MicroTec.Hr.BackendApi.Shared.Extensions
{
    public static class ApplicationBuilderMiddleWareExtenstion
    {
        public static WebApplication SetupMiddleWare(this WebApplication app)
        {
            
            app.UseMiddleware<CorrelationIdMiddleware>();
            app.UseMiddleware<LoggingMiddleware>();
            app.UseMiddleware<ExceptionMiddleware>();

            return app;
        }
    }
}
