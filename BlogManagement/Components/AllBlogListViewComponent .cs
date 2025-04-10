using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace BlogManagement.Components
{
    public class AllBlogListViewComponent:ViewComponent
    {
        private readonly IService _manager;

        public AllBlogListViewComponent(IService manager)
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
