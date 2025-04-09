using Entities.Models;
using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

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

        // Interface
        public Comment? GetOneComment(int id, bool trackChanges)
        {
            return FindByCondition(p => p.CommentID.Equals(id), trackChanges);
        }
    }
}
