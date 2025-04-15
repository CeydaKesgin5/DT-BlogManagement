using Entities.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using Microsoft.EntityFrameworkCore;
using Services;
using Repositories;

namespace CommentManagement.Controllers
{
    [Authorize]
    public class CommentController : Controller
    {
 
        private readonly IService _commentService;

       
        public CommentController(IService commentService)
        {
            _commentService = commentService;

        }

        [AllowAnonymous]

        public IActionResult Index()
        {
            var model = _commentService.CommentService.GetAllComments(false);
            return View(model);
        }
     
    
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public IActionResult Create([FromForm] Comment comment)
        {
            if (ModelState.IsValid)
            {
                _commentService.CommentService.CreateComment(comment);
                TempData["success"] = $"Yorumunuz başarıyla eklendi!";

                return RedirectToAction("Get", "Blog", new { id = comment.BlogId });
            }

            return RedirectToAction("Get", "Blog", new { id = comment.BlogId });
        }


        [Authorize]
        public IActionResult Update([FromRoute(Name = "id")] int id)
        {
            var model = _commentService.CommentService.GetOneComment(id, false);
            return View(model);
        }



        [HttpGet]
        [Authorize]
        public IActionResult Delete([FromRoute(Name = "id")] int id)
        {

            var comment = _commentService.CommentService.GetOneComment(id,false); // Yorum ID'sine göre yorumu bul
            if (comment != null)
            {
                _commentService.CommentService.DeleteOneComment(id);

            }
            TempData["success"] = $"Yorum silme işleminiz başarıyla gerçekleştirildi.";

            return RedirectToAction("Get", "Blog", new { id = comment.BlogId });

        }


    }
}
