using Greedy.Integration.Authentication;

namespace Greedy.WebApi.Middlewares
{
    public class AuthorizationMiddleware
    {
        private readonly RequestDelegate _next;
        //private readonly IAuthenticationService _authenticationService;

        //public AuthorizationMiddleware(RequestDelegate next, IAuthenticationService authenticationService)
        public AuthorizationMiddleware(RequestDelegate next)
        {
            _next = next;
            //_authenticationService = authenticationService;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            var jwtToken = httpContext.Request.Headers.Authorization;
            //var isAuthenticated = await _authenticationService.ValidateToken(jwtToken);
            var isAuthenticated = true;

            if (isAuthenticated)
            {
                throw new UnauthorizedAccessException();
            }

            await _next(httpContext);
        }
    }
}
