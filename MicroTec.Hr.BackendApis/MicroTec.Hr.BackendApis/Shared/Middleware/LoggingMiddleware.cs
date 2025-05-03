using Microsoft.AspNetCore.Mvc.Controllers;
using MicroTec.Hr.BackendApi.Shared.Helper;
using System.Diagnostics;
using System.Security.Claims;

namespace MicroTec.Hr.BackendApi.Shared.Middleware
{
    public class LoggingMiddleware(RequestDelegate next, ILogger<LoggingMiddleware> logger)
    {
        private readonly RequestDelegate _next = next;
        private readonly ILogger<LoggingMiddleware> _logger = logger;

        public async Task InvokeAsync(HttpContext context)
        {
            var path = context.Request.Path.Value?.ToLower();

            // ⛔ Skip logging for these paths
            if (path != null && (path.StartsWith("/health") || path.StartsWith("/swagger") || path.StartsWith("/favicon")))
            {
                await _next(context);
                return;
            }

            var stopwatch = Stopwatch.StartNew();

            // Enable buffering to read request body
            context.Request.EnableBuffering();
            var rawRequestBody = await ReadRequestBodyAsync(context.Request);
            var requestBody = LoggingHelper.MaskSensitiveFields(rawRequestBody);
            context.Request.Body.Position = 0;

            // Intercept the response body
            var originalBodyStream = context.Response.Body;
            using var responseBody = new MemoryStream();
            context.Response.Body = responseBody;

            await _next(context); // continue pipeline

            stopwatch.Stop();

            // Read the intercepted response
            context.Response.Body.Seek(0, SeekOrigin.Begin);
            var responseBodyText = await new StreamReader(context.Response.Body).ReadToEndAsync();
            context.Response.Body.Seek(0, SeekOrigin.Begin);
            var endpoint = context.GetEndpoint();

            var controllerName = endpoint?.Metadata
                .OfType<ControllerActionDescriptor>()
                .FirstOrDefault()?.ControllerName;

            var actionName = endpoint?.Metadata
                .OfType<ControllerActionDescriptor>()
                .FirstOrDefault()?.ActionName;

            var userId = context.User?.Identity?.IsAuthenticated == true
                ? context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value : "Anonymous";



            _logger.LogInformation(
                $"HTTP Request Method : {context.Request.Method} \n" +
                $"Correlation Id : {context.Response.Headers["X-Correlation-ID"]} \n" +
                $"Controller : {controllerName} \n" +
                $"Action Name : {actionName} \n" +
                $"User Details : {userId} \n" +
                $"Path : {context.Request.Path} \n" +
                $"Request Body {requestBody} \n" +
                $"Response Status Code {context.Response.StatusCode} \n" +
                $"Duration {stopwatch.ElapsedMilliseconds} \n" +
                $"Response Body {LoggingHelper.MaskSensitiveFields(responseBodyText)}");

            _logger.LogInformation("\n\n\n"); //Spacer
            // Copy the intercepted response back to the original stream
            await responseBody.CopyToAsync(originalBodyStream);
        }

        private static async Task<string> ReadRequestBodyAsync(HttpRequest request)
        {
            request.Body.Seek(0, SeekOrigin.Begin);
            using var reader = new StreamReader(request.Body, leaveOpen: true);
            var body = await reader.ReadToEndAsync();
            request.Body.Seek(0, SeekOrigin.Begin);
            return body;
        }
    }
}
