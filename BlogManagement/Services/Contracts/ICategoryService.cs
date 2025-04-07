using BlogManagement.Models;

namespace BlogManagement.Services.Contracts
{
    public interface ICategoryService
    {
        IEnumerable<Category> GetAllCategories(bool trackChanges);

    }
}
