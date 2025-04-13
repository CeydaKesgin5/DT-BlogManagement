using Entities.Models;

namespace Services.Contracts
{
    public interface ICommentService
    {
        IEnumerable<Comment> GetAllComments(bool trackChanges);
        Comment? GetOneComment(int id, bool trackChanges);
        void CreateComment(Comment comment);
        void UpdateOneComment(Comment comment);
        void DeleteOneComment(int id);

        public IEnumerable<Comment> GetCommentsByBlog(int blogId, bool trackChanges);



    }
}
