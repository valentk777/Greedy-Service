using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;

namespace Greedy.Integration.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {
        //TODO: fix
        //private static readonly string Secret = Environments.AppConfig.AuthenticationSecret;
        private static readonly string Secret = "db3OIsj+BXE9NZDy0t8W3TcNekrF+2d/1sFnWG4HnV8TZY30iTOdtVWJG8abWvB1GlOgJuQZdcF2Luqm/hccMw==";

        public string GenerateToken(string username, int expireHours)
        {
            var symmetricKey = Convert.FromBase64String(Secret);
            var tokenHandler = new JwtSecurityTokenHandler();
            var now = DateTime.UtcNow;
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                        {
                        new Claim(ClaimTypes.Name, username)
                    }),
                Expires = now.AddHours(Convert.ToInt32(expireHours)),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(symmetricKey), SecurityAlgorithms.HmacSha256Signature)
            };

            var stoken = tokenHandler.CreateToken(tokenDescriptor);
            var token = tokenHandler.WriteToken(stoken);

            return token;
        }

        //TODo: refactor
        public Task<bool> ValidateToken(string token)
        {
            return ValidateToken(token, out string username);
        }

        public Task<bool> ValidateToken(string token, out string username)
        {
            username = null;

            return Task.FromResult(true);
            //username = null;

            //try
            //{
            //    var simplePrinciple = GetPrincipal(token);
            //    var identity = simplePrinciple.Identity as ClaimsIdentity;

            //    if (identity == null)
            //    {
            //        return Task.FromResult<bool>(false);
            //    }

            //    if (!identity.IsAuthenticated)
            //    {
            //        return Task.FromResult<bool>(false);
            //    }

            //    var usernameClaim = identity.FindFirst(ClaimTypes.Name);
            //    username = usernameClaim?.Value;

            //    if (string.IsNullOrEmpty(username))
            //    {
            //        return Task.FromResult<bool>(false);
            //    }
            //}
            //catch (SecurityTokenValidationException)
            //{
            //    return Task.FromResult<bool>(false);
            //}

            //return Task.FromResult<bool>(true);
        }

        private ClaimsPrincipal GetPrincipal(string token)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var jwtToken = tokenHandler.ReadToken(token) as JwtSecurityToken;

                if (jwtToken == null)
                {
                    return null;
                }

                var symmetricKey = Convert.FromBase64String(Secret);

                var validationParameters = new TokenValidationParameters()
                {
                    RequireExpirationTime = true,
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    IssuerSigningKey = new SymmetricSecurityKey(symmetricKey)
                };

                var principal = tokenHandler.ValidateToken(token, validationParameters, out SecurityToken securityToken);

                return principal;
            }
            catch (Exception e)
            {
                //TODO: If we have a log then we definetly need to log the exception
                throw new SecurityTokenValidationException("failed to validate", e);
            }
        }
    }
}