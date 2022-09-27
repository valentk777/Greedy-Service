namespace Greedy.Domain.Users
{
    public interface IUserService
    {
        bool ValidateLoginCredentials(LoginCredentials credentials);

        bool ValidateFacebookLoginCredentials(FacebookLoginCredentials credentials);

        string GetUsername(FacebookLoginCredentials credentials);

        User Register(RegistrationCredentials credentials);
    }
}