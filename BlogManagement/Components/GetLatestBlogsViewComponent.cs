using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace BlogManagement.Components
{
    public class GetLatestBlogsViewComponent :ViewComponent
    {
        private readonly IServiceManager _service;

        public GetLatestBlogsViewComponent(IServiceManager service)
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
