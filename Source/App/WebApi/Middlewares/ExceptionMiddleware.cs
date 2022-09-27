using Shared.Serializers;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Net;

namespace Greedy.WebApi.Middlewares
{
    [ExcludeFromCodeCoverage]
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;
        private readonly ICustomJsonConverter _customJsonConverter;

        public ExceptionMiddleware(RequestDelegate next, ILoggerFactory loggerFactory, ICustomJsonConverter customJsonConverter)
        {
            _next = next;
            _logger = loggerFactory.CreateLogger<ExceptionMiddleware>();
            _customJsonConverter = customJsonConverter;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                var code = ex switch
                {
                    UnauthorizedAccessException => (int)HttpStatusCode.Unauthorized,
                    ValidationException => (int)HttpStatusCode.BadRequest,
                    _ => (int)HttpStatusCode.InternalServerError,
                };
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = code;

                _logger.LogError($"Error Code: {context.Response.StatusCode} | Message: {ex.Message}");

                await context.Response.WriteAsync(_customJsonConverter.Serilize(ex.Message));
            }
        }
    }
}
