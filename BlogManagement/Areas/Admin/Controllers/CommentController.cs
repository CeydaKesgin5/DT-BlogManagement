using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services;
using Services.Contracts;

namespace BlogManagement.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class CommentController: Controller
    {
        private readonly IServiceManager _commentService;

        public CommentController(IServiceManager commentService)
        {
            _commentService = commentService;
        }

    

        [HttpGet]
        [Authorize]
        public IActionResult Delete([FromRoute(Name = "id")] int id)
        {

            var comment = _commentService.CommentService.GetOneComment(id, false); // Yorum ID'sine göre yorumu bul
            if (comment != null)
            {
                _commentService.CommentService.DeleteOneComment(id);

            }

            return RedirectToAction("Get", "Blog", new { id = comment.BlogId });

        }
    }
}
