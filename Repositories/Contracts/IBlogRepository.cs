using Entities.Models;

namespace Repositories.Contracts
{
    public interface IBlogRepository : IRepository<Blog>
    {
        IQueryable<Blog> GetAllBlogs(bool trackChanges);
        Blog? GetOneBlog(int id, bool trackChanges);
        void CreateOneBlog(Blog Blog);
        void DeleteOneBlog(Blog blog);
        public IEnumerable<Blog> GetBlogsByCategory(int categoryId, bool trackChanges);





    }
}
