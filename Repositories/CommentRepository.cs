using Entities.Models;
using Repositories.Contracts;


namespace Repositories
{
    public class CommentRepository :Repository<Comment>, ICommentRepository
    {
        public CommentRepository(AppDbContext context) : base(context)
        {
        }


        public void CreateOneComment(Comment comment) => Create(comment);

        public void DeleteOneComment(Comment comment) => Remove(comment);

        public IQueryable<Comment> GetAllComments(bool trackChanges) => FindAll(trackChanges);

        public IEnumerable<Comment> GetCommentsByBlog(int blogId, bool trackChanges)
        {
            return FindAllByCondition(b => b.BlogId == blogId, trackChanges).ToList();

        }

        // Interface
        public Comment? GetOneComment(int id, bool trackChanges)
        {
            return FindByCondition(p => p.CommentID.Equals(id), trackChanges);
        }
    }
}
