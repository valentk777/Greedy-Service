using Greedy.Domain.Properties;
using System.ComponentModel.DataAnnotations;

namespace Greedy.Domain.Users
{
    public class UserService : IUserService
    {
        private readonly IUserManager _userManager;

        public UserService(IUserManager userManager)
        {
            _userManager = userManager;
        }

        private bool ValidateCredentials(LoginCredentials credentials)
        {
            return true;
            //return credentials.Username.IsUsernameValid() && credentials.Password.IsPasswordValid();
        }

        private bool ValidateCredentials(RegistrationCredentials credentials)
        {
            return true;

            //return credentials.Username.IsUsernameValid() && credentials.Password.IsPasswordValid() && credentials.Email.IsEmailValid();
        }

        public bool ValidateLoginCredentials(LoginCredentials credentials)
        {
            if (!ValidateCredentials(credentials))
            {
                throw new ValidationException(Resources.UserNotValid);
            }

            var user = _userManager.FindByUsername(credentials.Username, false);

            if (user == null)
            {
                user = _userManager.FindByEmail(credentials.Username, false);
            }

            if (user == null)
            {
                throw new ValidationException(Resources.UserNotFound);
            }

            //if (user.Password.Decrypt() != credentials.Password)
            //{
            //    throw new ValidationException(Resources.UserPasswordNotValid);
            //}

            return true;
        }

        public bool ValidateFacebookLoginCredentials(FacebookLoginCredentials credentials)
        {
            return true;
        }

        public string GetUsername(FacebookLoginCredentials credentials)
        {
            var user = _userManager.FindByEmail(credentials.Email, true);

            if (user == null)
            {
                throw new ValidationException(Resources.UserNotFound);
            }

            return user.Username;
        }

        public User Register(RegistrationCredentials credentials)
        {
            if (!ValidateCredentials(credentials))
            {
                throw new ValidationException(Resources.UserNotValid);
            }



            //if (_userManager.FindByUsername(credentials.Username, false) != null
            //    || _userManager.FindByUsername(credentials.Username, true) != null)
            //{
            //    return HelperClass.JsonHttpResponse<Object>(null);
            //}

            //if (_userManager.FindByEmail(credentials.Email, false) != null
            //    || _userManager.FindByEmail(credentials.Email, true) != null)
            //{
            //    return HelperClass.JsonHttpResponse<Object>(null);
            //}

            var user = _userManager.Register(credentials);

            return user;
        }
    }
}