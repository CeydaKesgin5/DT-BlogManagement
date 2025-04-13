namespace Repositories.Contracts
{
    public interface IRepositoryManager
    {
        IBlogRepository Blog { get; }
        ICategoryRepository Category { get; }

        ICommentRepository Comment { get; }

        IUserRepository User { get; }
        void Save();
    }
}
