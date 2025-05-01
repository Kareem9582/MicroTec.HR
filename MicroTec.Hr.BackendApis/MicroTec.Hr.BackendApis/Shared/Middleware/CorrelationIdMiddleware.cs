using MicroTec.Hr.BackendApi.Shared.Helper;

namespace MicroTec.Hr.BackendApi.Shared.Middleware
{
    public class CorrelationIdMiddleware(RequestDelegate next, ILogger<CorrelationIdMiddleware> logger)
    {
        private const string HeaderKey = "X-Correlation-ID";
        private readonly RequestDelegate _next = next;
        private readonly ILogger<CorrelationIdMiddleware> _logger = logger;

        public async Task InvokeAsync(HttpContext context)
        {
            string correlationId;

            if (context.Request.Headers.TryGetValue(HeaderKey, out var headerValue) && !string.IsNullOrWhiteSpace(headerValue))
            {
                correlationId = headerValue!;
            }
            else
            {
                correlationId = Guid.NewGuid().ToString();
            }

            context.Items["CorrelationId"] = correlationId;
            context.Response.Headers[HeaderKey] = correlationId;

            using var scope = LoggingHelper.SetLoggingScope(_logger, ("CorrelationId", correlationId));
            await _next(context);
        }
    }
}
