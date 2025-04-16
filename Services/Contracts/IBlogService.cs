using Entities.DTOs.BlogDTOs;
using Entities.Models;

namespace Services.Contracts
{
    public interface IBlogService
    {
       
        IEnumerable<Blog> GetAllBlogs(bool trackChanges);
        Blog? GetOneBlog(int id, bool trackChanges);
        void CreateBlog(Blog blog);
        void UpdateOneBlog(Blog blog);
        void DeleteOneBlog(int id);

        public IEnumerable<Blog> GetBlogsByCategory(int categoryId, bool trackChanges);
        public IEnumerable<Blog> GetBlogsByUserId(string userId, bool trackChanges);

        public IEnumerable<Blog> GetLatestBlogs(bool trackChanges);

    }
}
