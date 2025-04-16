using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;


namespace BlogManagement.Components
{
    public class CategoryBlogListViewComponent : ViewComponent
    {
        private readonly IServiceManager _manager;

        public CategoryBlogListViewComponent(IServiceManager manager)
        {
            _manager = manager;
        }

        public IViewComponentResult Invoke(int categoryId)
        {
            var blogs = _manager.BlogService.GetBlogsByCategory(categoryId, false);
            return View(blogs);
        }
    }
}
