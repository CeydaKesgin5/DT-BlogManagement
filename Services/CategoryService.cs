using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;
using Services.Contracts;

namespace BlogManagement.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IRepositoryManager _repositoryManager;

        public CategoryService(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public void CreateCategory(Category category)
        {
            _repositoryManager.Category.Create(category);
            _repositoryManager.Save();
        }

        public void DeleteOneCategory(int id)
        {
            Category category = GetOneCategory(id, false);
            if(category is not null)
            {
                _repositoryManager.Category.DeleteOneCategory(category);
                _repositoryManager.Save();
            }
        }

        public IEnumerable<Category> GetAllCategories(bool trackChanges)
        {
            return _repositoryManager.Category.FindAll(trackChanges);
        }

        public IEnumerable<Category> GetCategoriesWithBlogs(bool trackChanges)
        {
            return _repositoryManager.Category.GetCategoriesWithBlogs( trackChanges);
        }

        public Category? GetOneCategory(int id, bool trackChanges)
        {
            var category = _repositoryManager.Category.GetOneCategory(id, trackChanges);
            if (category is null)
                throw new Exception("Blog not found!");
            return category;
        }

      
    }
}
