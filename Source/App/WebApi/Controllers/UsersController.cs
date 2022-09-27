using Greedy.Domain.Users;
using Greedy.Integration.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.CodeAnalysis;
using System.Net;

namespace Greedy.WebApi.Controllers
{
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Route("api/users")]
    public class UsersController : ControllerBase
    {
        private readonly ILogger<UsersController> _logger;
        private IUserService _userService;
        private IAuthenticationService _authenticationService;

        public UsersController(ILogger<UsersController> logger, IUserService userService, IAuthenticationService authenticationService)
        {
            _logger = logger;
            _userService = userService;
            _authenticationService = authenticationService;
        }

        [HttpPut]
        [Route("login")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(string))]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult LoginWithPassword([FromBody] LoginCredentials credentials)
        {
            _logger.LogError("Param", credentials);
            _userService.ValidateLoginCredentials(credentials);

            var token = _authenticationService.GenerateToken(credentials.Username);

            return Ok(token);
        }

        //[HttpPut]
        //[Route("login")]
        //[ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(string))]
        //[ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        //[ProducesResponseType((int)HttpStatusCode.BadRequest)]
        //public IActionResult LoginWithFacebook([FromBody] FacebookLoginCredentials credentials)
        //{
        //    _userService.ValidateFacebookLoginCredentials(credentials);
        //    var username = _userService.GetUsername(credentials);
        //    var token = _authenticationService.GenerateToken(username);

        //    return Ok(token);
        //}

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(User))]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult AddNewUser([FromBody] RegistrationCredentials credentials)
        {
            var user = _userService.Register(credentials);
            return Ok(user);
        }

        //[HttpPut]
        //[Route("email")]
        //[ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(List<string>))]
        //[ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        //[ProducesResponseType((int)HttpStatusCode.BadRequest)]
        //public IActionResult ChangeEmail()
        //{
        //    throw new NotImplementedException();
        //}

        //[HttpPut]
        //[Route("password")]
        //[ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(List<string>))]
        //[ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        //[ProducesResponseType((int)HttpStatusCode.BadRequest)]
        //public IActionResult ChangePassword()
        //{
        //    throw new NotImplementedException();
        //}
    }
}