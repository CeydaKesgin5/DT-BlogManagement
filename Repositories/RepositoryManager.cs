using Repositories.Contracts;

namespace Repositories
{
    
        public class RepositoryManager : IRepositoryManager
        {
            private readonly AppDbContext _context;
            private readonly IBlogRepository _blogRepository;
            private readonly ICategoryRepository _categoryRepository;
            private readonly ICommentRepository _commentRepository;
        public RepositoryManager(IBlogRepository blogRepository,
        AppDbContext context,
        ICategoryRepository categoryRepository,
        ICommentRepository commentRepository)
        {
            _context = context;
            _blogRepository = blogRepository;
            _categoryRepository = categoryRepository;
            _commentRepository = commentRepository;
        }

        public IBlogRepository Blog => _blogRepository;

        public ICategoryRepository Category => _categoryRepository;
        public ICommentRepository Comment => _commentRepository;
        
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}

