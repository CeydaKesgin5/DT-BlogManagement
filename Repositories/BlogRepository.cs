using Repositories.Contracts;
using Entities.Models;

namespace Repositories
{
    public class BlogRepository : Repository<Blog>, IBlogRepository
    {
        public BlogRepository(AppDbContext context) : base(context)
        {

        }

        public void CreateOneBlog(Blog blog) => Create(blog);

        public void DeleteOneBlog(Blog blog) => Remove(blog);

        public IQueryable<Blog> GetAllBlogs(bool trackChanges) => FindAll(trackChanges);

        // Interface
        public Blog? GetOneBlog(int id, bool trackChanges)
        {
            return FindByCondition(p => p.Id.Equals(id), trackChanges);
        }

        
        public IEnumerable<Blog> GetBlogsByCategory(int categoryId, bool trackChanges)
        {
            return FindAllByCondition(b => b.CategoryId == categoryId, trackChanges).ToList();
        }

        public IEnumerable<Blog> GetBlogsByUserId(string userId, bool trackChanges)
        {
            return FindAllByCondition(b => b.UserId == userId, trackChanges).ToList();

        }
    }
   
}
