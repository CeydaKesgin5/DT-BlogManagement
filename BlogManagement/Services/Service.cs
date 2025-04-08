using BlogManagement.Services.Contracts;

namespace BlogManagement.Services
{
    public class Service : IService
    {
        private readonly IBlogService _blogService;
        private readonly ICategoryService _categoryService;
        private readonly IAuthService _authService;
        public Service(IBlogService blogService,
        ICategoryService categoryService,
        IAuthService authService)
        {
            _blogService = blogService;
            _categoryService = categoryService;
            _authService = authService;
        }

        public IBlogService BlogService => _blogService;

        public ICategoryService CategoryService => _categoryService;
        public IAuthService AuthService => _authService;
    }
}
