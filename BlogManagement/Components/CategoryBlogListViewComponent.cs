using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;


namespace BlogManagement.Components
{
    public class CategoryBlogListViewComponent : ViewComponent
    {
        private readonly IService _manager;

        public CategoryBlogListViewComponent(IService manager)
        {
            _manager = manager;
        }

        public IViewComponentResult Invoke(int categoryId)
        {
            //var categories = _manager.CategoryService.GetAllCategories(false);
            //return View(categories);
            var blogs = _manager.BlogService.GetBlogsByCategory(categoryId, false);
            return View(blogs);
        }
    }
}
