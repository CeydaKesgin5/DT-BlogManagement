using Entities.Models;


namespace Repositories.Contracts
{
    public interface ICommentRepository : IRepository<Comment>
    {
        IQueryable<Comment> GetAllComments(bool trackChanges);
        Comment? GetOneComment(int id, bool trackChanges);
        void CreateOneComment(Comment Comment);
        void DeleteOneComment(Comment comment);
        public IEnumerable<Comment> GetCommentsByBlog(int blogId, bool trackChanges);

    }
}
