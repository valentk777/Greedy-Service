using System.Diagnostics.CodeAnalysis;

namespace Greedy.WebApi.Middlewares
{
    [ExcludeFromCodeCoverage]
    public class CorrelationIdMiddleware
    {
        private const string CorrelationIdHeaderKey = "X-Correlation-ID";

        private readonly RequestDelegate _next;
        private readonly ILogger<CorrelationIdMiddleware> _logger;

        public CorrelationIdMiddleware(RequestDelegate next, ILoggerFactory loggerFactory)
        {
            _next = next;
            _logger = loggerFactory.CreateLogger<CorrelationIdMiddleware>();
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            var isCorrelationIdPassed = httpContext.Request.Headers.TryGetValue(CorrelationIdHeaderKey, out var correlationIds);
            var correlationId = correlationIds.FirstOrDefault() ?? $"Greedy-{Guid.NewGuid()}";

            using (_logger.BeginScope(new Dictionary<string, object> { { CorrelationIdHeaderKey, correlationId } }))
            {
                _logger.LogInformation($"{CorrelationIdHeaderKey}: {correlationId}");
                await _next(httpContext);
            }
        }
    }
}
