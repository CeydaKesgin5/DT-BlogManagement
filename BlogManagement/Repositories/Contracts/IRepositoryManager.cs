namespace BlogManagement.Repositories.Contracts
{
    public interface IRepositoryManager
    {
        IBlogRepository Blog { get; }
        ICategoryRepository Category { get; }
        void Save();
    }
}
