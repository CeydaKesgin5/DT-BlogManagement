
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;

namespace Repositories
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(AppDbContext context) : base(context)
        {
        }

        public void CreateOneCategory(Category category) => Create(category);

        public void DeleteOneCategory(Category category) => Remove(category);
        public IEnumerable<Category> GetCategoriesWithBlogs(bool trackChanges)
        {
            return trackChanges
        ? _context.Categories.Include(c => c.Blogs).ToList()
        : _context.Categories.Include(c => c.Blogs).AsNoTracking().ToList();
        }
      

        public Category? GetOneCategory(int id, bool trackChanges)
        {
            return FindByCondition(p => p.CategoryID.Equals(id), trackChanges);
        }
    }
}
