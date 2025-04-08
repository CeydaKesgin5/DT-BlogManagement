namespace Repositories.Contracts
{
    public interface IRepositoryManager
    {
        IBlogRepository Blog { get; }
        ICategoryRepository Category { get; }
        void Save();
    }
}
