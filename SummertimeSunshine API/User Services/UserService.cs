using SummertimeSunshine_API.Exceptions;
using SummertimeSunshine_API.Products_Model;
using SummertimeSunshine_API.Repo;

namespace SummertimeSunshine_API.User_Services
{
    public class UserService : IUserService
    {
        private readonly IUserlistRepo repo;
        public UserService(IUserlistRepo repo)
        {
            this.repo = repo;
        }

        public bool Login(string username, string password)
        {
            var existingUser = repo.GetUser(username, password);

            if (existingUser == null)
            {
                throw new UserDoesNotExistException($"The username or password you entered is incorrect. Please try again.");
            }

            if (existingUser.UserUsername == username && existingUser.UserPassword == password)
            {
                return true;
            }
            else
            {
                throw new UserAlreadyExistException($"User with username: {username} already exists.");
            }
        }


        public int Register(Userlist userlist)
        {
            var existingUser = repo.GetUser(userlist.UserUsername);

            if (existingUser != null)
            {
                throw new UserAlreadyExistException($"User with username:{existingUser.UserUsername} already exists.");
            }

            return repo.Register(userlist);
        }
    }
}
