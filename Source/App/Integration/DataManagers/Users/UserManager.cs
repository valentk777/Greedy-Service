using System.Data.Entity;
using Greedy.Integration.Extensions;
using Greedy.Domain.Users;

namespace Greedy.Integration.DataManagers.Users
{
    public class UserManager : ManagerBase, IUserManager
    {
        public UserManager(DbContext context) : base(context) { }

        public User Register(RegistrationCredentials credentials)
        {
            var user = new User()
            {
                Username = credentials.Username.ToLower(),
                Password = credentials.Password.Encrypt(),
                Email = credentials.Email.ToLower(),
                Fullname = credentials.Fullname,
                IsFacebookUser = false
            };

            return AddUser(user);
        }

        public List<User> GetUser() =>
            context
                .Set<UserDataModel>()
                .Select(ToUser)
                .ToList();

        public User AddUser(User user)
        {
            context
                .Set<UserDataModel>()
                .Add(new UserDataModel()
                {
                    Username = user.Username,
                    Email = user.Email,
                    Password = user.Password,
                    FullName = user.Fullname,
                    IsFacebookUser = user.IsFacebookUser
                });

            context.SaveChanges();

            return user;
        }

        public User FindByUsername(string username, bool isFacebookUser) =>
            context
                .Set<UserDataModel>()
                .Where(user => user.Username.ToLower() == username.ToLower() && user.IsFacebookUser == isFacebookUser)
                .Select(ToUser)
                .FirstOrDefault();

        public User FindByEmail(string email, bool isFacebookUser) =>
            context
                .Set<UserDataModel>()
                .Where(user => user.Email.ToLower() == email.ToLower() && user.IsFacebookUser == isFacebookUser)
                .Select(ToUser)
                .FirstOrDefault();

        public bool UpdateEmail(string username, string password, string newEmail)
        {
            var userToUpdate = GetUserDataModel(username, password);

            if (userToUpdate == null)
            {
                return false;
            }

            userToUpdate.Email = newEmail;
            context.SaveChanges();
            return true;
        }

        public bool UpdatePassword(string username, string password, string newEncryptedPassword)
        {
            var userToUpdate = GetUserDataModel(username, password);

            if (userToUpdate == null)
            {
                return false;
            }

            userToUpdate.Password = newEncryptedPassword;
            context.SaveChanges();

            return true;
        }

        private UserDataModel GetUserDataModel(string username, string password) =>
            context
                .Set<UserDataModel>()
                .FirstOrDefault(x => x.Username == username && x.Password == password);

        private User ToUser(UserDataModel user) =>
            user == null
            ? null
            : new User
            {
                Username = user.Username,
                Fullname = user.FullName,
                Email = user.Email,
                Password = user.Password,
                IsFacebookUser = user.IsFacebookUser
            };
    }
}
