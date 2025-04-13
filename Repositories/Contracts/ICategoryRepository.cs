using Entities.Models;

namespace Repositories.Contracts
{
    public interface ICategoryRepository: IRepository<Category>
    {
        Category? GetOneCategory(int id, bool trackChanges);
        public IEnumerable<Category> GetCategoriesWithBlogs(bool trackChanges);

        void CreateOneCategory(Category category);
        void DeleteOneCategory(Category category);
    }
}
