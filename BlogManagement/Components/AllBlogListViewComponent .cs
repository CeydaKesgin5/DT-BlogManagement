using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace BlogManagement.Components
{
    public class AllBlogListViewComponent:ViewComponent
    {
        private readonly IServiceManager _manager;

        public AllBlogListViewComponent(IServiceManager manager)
        {
            _manager = manager;
        }

        public IViewComponentResult Invoke()
        {
            var blogs = _manager.BlogService.GetAllBlogs(false);
            return View(blogs);
        }
    }
}
