using AutoMapper;
using Entities.DTOs.BlogDTOs;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
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

        public IEnumerable<Blog> GetLatestBlogs(bool trackChanges)
        {
            return  _manager.Blog.FindAll(false).OrderByDescending(b => b.PublishedAt).ToList();
        }

        public IEnumerable<Blog> GetBlogsByUserId(string userId, bool trackChanges)
        {
            return _manager.Blog.GetBlogsByUserId(userId, trackChanges);
        }
    }
    
}

