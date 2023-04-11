using RedditApp.Data.Models;

namespace RedditApp.Services
{
    public class UserService
    {
        private readonly UserRepository _userRepository;

        public UserService(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public List<User> GetAllUsers()
        {
            return _userRepository.GetAll();
        }

        public User GetUserById(int id)
        {
            return _userRepository.GetById(id);
        }

        public User CreateUser(User user)
        {
            return _userRepository.Create(user);
        }

        public User UpdateUser(User user)
        {
            return _userRepository.Update(user);
        }

        public void DeleteUser(int id)
        {
            _userRepository.Delete(id);
        }

        public bool Login(LoginCredentials credentials)
        {
            var user = _userRepository.GetAll().FirstOrDefault(u => u.Username == credentials.Username);

            if (user != null && user.Password == credentials.Password)
            {
                // TOD 0: Add some function on successful login
                return true;
            }

            return false;
        }
    }
}
