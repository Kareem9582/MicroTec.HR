using MicroTec.Hr.BackendApi.Shared.Responess;
using System.Net;
using System.Text.Json;

namespace MicroTec.Hr.BackendApi.Shared.Middleware
{
    public class ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger, IHostEnvironment env)
    {
        private readonly RequestDelegate _next = next;
        private readonly ILogger<ExceptionMiddleware> _logger = logger;
        private readonly IHostEnvironment _env = env;

        private static readonly JsonSerializerOptions _jsonOptions = new()
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex) //Will differ based on different environment  
            {
                _logger.LogError(ex, "An error occurred: {ErrorMessage}", ex.Message);

                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                var errorResponse = _env.IsDevelopment()
                ? CreateDevResponse(ex)
                : CreateProductionResponse();

                var json = JsonSerializer.Serialize(errorResponse, _jsonOptions);

                await context.Response.WriteAsync(json);
            }
        }

        private static ErrorResponse CreateDevResponse(Exception ex) => new()
        {
            Status = (int)HttpStatusCode.InternalServerError,
            Error = ex.Message,
            StackTrace = ex.StackTrace
        };

        private static ErrorResponse CreateProductionResponse() => new()
        {
            Status = (int)HttpStatusCode.InternalServerError,
            Error = "An unexpected error occurred. Please contact support.",
            StackTrace = null
        };
    }
}
