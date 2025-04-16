using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services.Contracts;
using System.Security.Claims;

namespace BlogManagement.Pages
{
    public class UserModel : PageModel
    {
        private readonly IService _manager;
        private readonly IBlogService _blogService;
        public IEnumerable<Blog> BlogsByUser { get; set; }
        public UserModel(IService manager, IBlogService blogService)
        {
            _manager = manager;
            _blogService = blogService;

        }
        public IActionResult OnGet(string userId)
        {
            ViewData["ActiveTab"] = "Blogs";
            userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            BlogsByUser = _manager.BlogService.GetBlogsByUserId(userId, false);
            return Page();
        }
    }
}
