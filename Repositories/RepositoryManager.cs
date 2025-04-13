using Repositories.Contracts;

namespace Repositories
{
    
        public class RepositoryManager : IRepositoryManager
        {
            private readonly AppDbContext _context;
            private readonly IBlogRepository _blogRepository;
            private readonly ICategoryRepository _categoryRepository;
            private readonly ICommentRepository _commentRepository;
            private readonly IUserRepository _userRepository;
        public RepositoryManager(IBlogRepository blogRepository,
        AppDbContext context,
        ICategoryRepository categoryRepository,
        ICommentRepository commentRepository,
        IUserRepository userRepository)
        {
            _context = context;
            _blogRepository = blogRepository;
            _categoryRepository = categoryRepository;
            _commentRepository = commentRepository;
            _userRepository = userRepository;
        }

        public IBlogRepository Blog => _blogRepository;

        public ICategoryRepository Category => _categoryRepository;
        public ICommentRepository Comment => _commentRepository;
        
        public IUserRepository User => _userRepository;
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}

