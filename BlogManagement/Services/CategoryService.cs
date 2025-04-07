using BlogManagement.Models;
using BlogManagement.Repositories.Contracts;
using BlogManagement.Services.Contracts;

namespace BlogManagement.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IRepositoryManager _repositoryManager;

        public CategoryService(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public IEnumerable<Category> GetAllCategories(bool trackChanges)
        {
            return _repositoryManager.Category.FindAll(trackChanges);
        }

   
    }
}
