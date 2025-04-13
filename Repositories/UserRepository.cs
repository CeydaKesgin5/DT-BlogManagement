using Entities.Models;
using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(AppDbContext context) : base(context)
        {

        }

        public void CreateOneUser(User User) => Create(User);

        public void DeleteOneUser(User User) => Remove(User);

        public IQueryable<User> GetAllUsers(bool trackChanges) => FindAll(trackChanges);

   

        public User? GetOneUser(string id, bool trackChanges)
        {
            return FindByCondition(p => p.Id.Equals(id), trackChanges);

        }
    }

}
