using Entities.Models;


namespace Services.Contracts
{
    public interface IUserService
    {
        IEnumerable<User> GetAllUsers(bool trackChanges);
        User? GetOneUser(string id, bool trackChanges);
        void CreateUser(User User);
        void UpdateUserRole(User User);
        void DeleteOneUser(string id);
    }
}
