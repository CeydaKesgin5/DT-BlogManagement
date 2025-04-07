using BlogManagement.Services.Contracts;

namespace BlogManagement.Services
{
    public class Service : IService
    {
        private readonly IBlogService _blogService;
        private readonly ICategoryService _categoryService;

        public Service(IBlogService blogService,
        ICategoryService categoryService)
        {
            _blogService = blogService;
            _categoryService = categoryService;
        }

        public IBlogService BlogService => _blogService;

        public ICategoryService CategoryService => _categoryService;
    }
}
