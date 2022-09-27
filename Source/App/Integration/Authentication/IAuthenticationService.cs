namespace Greedy.Integration.Authentication
{
    public interface IAuthenticationService
    {
        Task<bool> ValidateToken(string token, out string username);

        Task<bool> ValidateToken(string token);

        string GenerateToken(string username, int expireHours = 24);
    }
}