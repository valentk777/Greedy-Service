namespace Greedy.Domain.Users
{
    public interface IUserManager
    {
        User Register(RegistrationCredentials credentials);

        List<User> GetUser();

        User AddUser(User user);

        User FindByUsername(string username, bool isFacebookUser);

        User FindByEmail(string email, bool isFacebookUser);

        bool UpdateEmail(string username, string encryptedPassword, string newEmail);

        bool UpdatePassword(string username, string encryptedPassword, string newEncryptedPassword);
    }
}