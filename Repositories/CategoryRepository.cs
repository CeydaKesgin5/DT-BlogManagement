
using Entities.Models;
using Repositories.Contracts;

namespace Repositories
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(AppDbContext context) : base(context)
        {
        }

        public Category? GetOneCategory(int id, bool trackChanges)
        {
            return FindByCondition(p => p.CategoryID.Equals(id), trackChanges);
        }
    }
}
