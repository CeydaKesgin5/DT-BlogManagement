
using Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using Entities.Models;
using System.Linq;

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


    }
    //    private readonly AppDbContext _context;

    //    public BlogRepository(AppDbContext context) : base(context)
    //    {
    //    }

    //    public async Task<IEnumerable<Blog>> GetAllBlogsAsync()
    //    {
    //        return await _context.Blogs.Include(b => b.User).Include(b => b.Category).ToListAsync();
    //    }

    //    public async Task<Blog> GetBlogByIdAsync(int id)
    //    {
    //        return await _context.Blogs.Include(b => b.User).Include(b => b.Category)
    //            .FirstOrDefaultAsync(b => b.Id == id);
    //    }

    //    public async Task CreateBlogAsync(Blog blog)
    //    {
    //        await _context.Blogs.AddAsync(blog);
    //        await _context.SaveChangesAsync();
    //    }

    //    public async Task UpdateBlogAsync(Blog blog)
    //    {
    //        _context.Blogs.Update(blog);
    //        await _context.SaveChangesAsync();
    //    }

    //    public async Task DeleteBlogAsync(int id)
    //    {
    //        var blog = await GetBlogByIdAsync(id);
    //        if (blog != null)
    //        {
    //            _context.Blogs.Remove(blog);
    //            await _context.SaveChangesAsync();
    //        }
    //    }

}
