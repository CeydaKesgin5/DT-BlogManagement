using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace StoreApp.Components
{
    public class CategoriesMenuViewComponent : ViewComponent
    {
        private readonly IService _manager;

        public CategoriesMenuViewComponent(IService manager)
        {
            _manager = manager;
        }

        public IViewComponentResult Invoke()
        {
            var categories = _manager.CategoryService.GetAllCategories(false);
            return View(categories);
        }
    }
}
