
using Entities.Models;

namespace Repositories.Contracts
{
    public interface IUserRepository : IRepository<User>
    {
        IQueryable<User> GetAllUsers(bool trackChanges);
        User? GetOneUser(string id, bool trackChanges);
        void CreateOneUser(User user);
        void DeleteOneUser(User user);

    }
}
