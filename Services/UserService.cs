using Entities.Models;
using Repositories.Contracts;
using Services.Contracts;

namespace Services
{
    public class UserService : IUserService
    {
        private readonly IRepositoryManager _manager;

        public UserService(IRepositoryManager manager)
        {
            _manager = manager;
        }
      


       


        public IEnumerable<User> GetAllUsers(bool trackChanges)
        {
            return _manager.User.GetAllUsers(trackChanges);
        }

        public User? GetOneUser(string id, bool trackChanges)
        {
            var user = _manager.User.GetOneUser(id, trackChanges);
            if (user is null)
                throw new Exception("User not found!");
            return user;
        }

        public void CreateUser(User User)
        {
            _manager.User.Create(User);
            _manager.Save();
        }

        public void UpdateUserRole(User User)
        {
            var entity = _manager.User.GetOneUser(User.Id, true);
            //entity. = User.Role;
            _manager.Save();
        }

        public void DeleteOneUser(string id)
        {
            User User = GetOneUser(id, false);
            if (User is not null)
            {
                _manager.User.DeleteOneUser(User);
                _manager.Save();
            }
        }
    }
}
