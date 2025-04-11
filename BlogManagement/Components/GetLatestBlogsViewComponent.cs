using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace BlogManagement.Components
{
    public class GetLatestBlogsViewComponent :ViewComponent
    {
        private readonly IService _service;

        public GetLatestBlogsViewComponent(IService service)
        {
            _service = service;
        }

        public IViewComponentResult Invoke()
        {
                var allBlogs = _service.BlogService.GetLatestBlogs(false);
                return View(allBlogs);
        }

    }
}
