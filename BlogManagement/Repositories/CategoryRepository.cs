using BlogManagement.Data;
using BlogManagement.Models;
using BlogManagement.Repositories.Contracts;
using BlogManagement.Services.Contracts;

namespace BlogManagement.Repositories
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(AppDbContext context) : base(context)
        {
        }
    }
}
