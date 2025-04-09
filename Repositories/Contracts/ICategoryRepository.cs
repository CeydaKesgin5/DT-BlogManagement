using Entities.Models;

namespace Repositories.Contracts
{
    public interface ICategoryRepository: IRepository<Category>
    {
        Category? GetOneCategory(int id, bool trackChanges);

    }
}
