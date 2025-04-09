using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Contracts
{
    public interface ICommentRepository : IRepository<Comment>
    {
        IQueryable<Comment> GetAllComments(bool trackChanges);
        Comment? GetOneComment(int id, bool trackChanges);
        void CreateOneComment(Comment Comment);
        void DeleteOneComment(Comment blog);
    }
}
