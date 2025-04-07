using BlogManagement.Data;
using BlogManagement.Repositories.Contracts;

namespace BlogManagement.Repositories
{
    
        public class RepositoryManager : IRepositoryManager
        {
            private readonly AppDbContext _context;
            private readonly IBlogRepository _blogRepository;
            private readonly ICategoryRepository _categoryRepository;

            public RepositoryManager(IBlogRepository blogRepository,
            AppDbContext context,
            ICategoryRepository categoryRepository)
            {
                _context = context;
                _blogRepository = blogRepository;
                _categoryRepository = categoryRepository;
            }

            public IBlogRepository Blog => _blogRepository;

            public ICategoryRepository Category => _categoryRepository;


        public void Save()
            {
                _context.SaveChanges();
            }
        }
    }

