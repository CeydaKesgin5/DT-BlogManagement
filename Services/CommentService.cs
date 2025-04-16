using Entities.Models;
using Repositories.Contracts;
using Services.Contracts;


namespace Services
{
    public class CommentService : ICommentService
    {
        private readonly IRepositoryManager _manager;

        public CommentService(IRepositoryManager manager)
        {
            _manager = manager;        
        }
        public void CreateComment(Comment comment)
        {
            _manager.Comment.Create(comment);
            _manager.Save();
        }

        public void DeleteOneComment(int id)
        {
            Comment comment = GetOneComment(id, false);
            if (comment is not null)
            {
                _manager.Comment.DeleteOneComment(comment);
                _manager.Save();
            }
        }

        public IEnumerable<Comment> GetAllComments(bool trackChanges)
        {
            return _manager.Comment.GetAllComments(trackChanges);
        }

        public IEnumerable<Comment> GetCommentsByBlog(int blogId, bool trackChanges)
        {
            return _manager.Comment.GetCommentsByBlog(blogId, trackChanges);
        }

        public Comment? GetOneComment(int id, bool trackChanges)
        {
            var comment = _manager.Comment.GetOneComment(id, trackChanges);
            if (comment is null)
                throw new Exception("Comment not found!");
            return comment;
        }

        public void UpdateOneComment(Comment comment)
        {
            var entity = _manager.Comment.GetOneComment(comment.CommentID, true);
            entity.CommentText= comment.CommentText;
            _manager.Save();
        }
    }
}
