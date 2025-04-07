using BlogManagement.DTOs.BlogDTOs;
using BlogManagement.Models;

namespace BlogManagement.Services.Contracts
{
    public interface IBlogService
    {
        //Task<List<Blog>> GetAllBlogs();
        //Task CreateBlogAsync(CreateBlogDto blogDto);
        //Task UpdateBlogAsync(UpdateBlogDto blogDto);
        //Task<Category> GetByIdBlogAsync(int id);
        //Task DeleteOneBlogAsync(int id);



        IEnumerable<Blog> GetAllBlogs(bool trackChanges);
        Blog? GetOneBlog(int id, bool trackChanges);
        void CreateBlog(Blog blog);
        void UpdateOneBlog(Blog blog);
        void DeleteOneBlog(int id);
    }
}
