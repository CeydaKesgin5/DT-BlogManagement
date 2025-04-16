using Services.Contracts;

namespace Services
{
    public class Service : IService
    {
        private readonly IBlogService _service;
        private readonly ICategoryService _categoryService;
        private readonly IAuthService _authService;
        private readonly ICommentService _commentService;
        public Service(IBlogService blogService,
        ICategoryService categoryService,
        IAuthService authService,
        ICommentService commentService)
        {
            _service = blogService;
            _categoryService = categoryService;
            _authService = authService;
            _commentService = commentService;
        }

        public IBlogService BlogService => _service;

        public ICategoryService CategoryService => _categoryService;
        public IAuthService AuthService => _authService;

        public ICommentService CommentService => _commentService;

    }
}
