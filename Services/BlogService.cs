using AutoMapper;
using Entities.DTOs.BlogDTOs;
using Entities.Models;
using Repositories;
using Repositories.Contracts;
using Services.Contracts;

namespace Services
{
    public class BlogService : IBlogService
    {
        private readonly IRepositoryManager _manager;

        public BlogService(IRepositoryManager manager)
        {
            _manager = manager;
        }
        public void CreateBlog(Blog blog)
        {
            _manager.Blog.Create(blog);
            _manager.Save();
        }

        public void DeleteOneBlog(int id)
        {
            Blog blog = GetOneBlog(id, false);
            if (blog is not null)
            {
                _manager.Blog.DeleteOneBlog(blog);
                _manager.Save();
            }
        }

        public IEnumerable<Blog> GetAllBlogs(bool trackChanges)
        {
            return _manager.Blog.GetAllBlogs(trackChanges);
        }

        public Blog? GetOneBlog(int id, bool trackChanges)
        {
            var blog = _manager.Blog.GetOneBlog(id, trackChanges);
            if (blog is null)
                throw new Exception("Blog not found!");
            return blog;
        }

        public IEnumerable<Blog> GetBlogsByCategory(int categoryId, bool trackChanges)
        {
            return _manager.Blog.GetBlogsByCategory(categoryId, trackChanges);
        }


        public void UpdateOneBlog(Blog blog)
        {
            var entity = _manager.Blog.GetOneBlog(blog.Id, true);
            entity.Title = blog.Title;
            entity.Content = blog.Content;
            _manager.Save();
        }
    }
    //private readonly IMapper _mapper;
    //private readonly IBlogRepository _blogRepository;
    //public BlogService(IMapper mapper, IBlogRepository blogRepository)
    //{
    //    _mapper = mapper;
    //    _blogRepository = blogRepository;
    //}

    //public async Task CreateBlogAsync(CreateBlogDto blogDto)
    //{
    //    var blog = _mapper.Map<Blog>(blogDto);

    //    await _blogRepository.AddAsync(blog);
    //}

    //public async Task DeleteOneBlogAsync(int id)
    //{
    //    await _blogRepository.DeleteAsync(id);
    //}

    //public async Task<List<Blog>> GetAllBlogs()
    //{
    //    var blogs = await _blogRepository.GetAllAsync();
    //    return blogs.ToList();
    //}

    //public async Task<Blog> GetByIdBlogAsync(int id)
    //{
    //    return await _blogRepository.GetByIdAsync(id);


    //}

    //public async Task UpdateBlogAsync(UpdateBlogDto blogDto)
    //{
    //    var blog = _mapper.Map<Blog>(blogDto);

    //    await _blogRepository.UpdateAsync(blog);
    //}

    //Task<Category> IBlogService.GetByIdBlogAsync(int id)
    //{
    //    throw new NotImplementedException();
    //}

}

