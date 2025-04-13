using Entities.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Repositories;
using Services;
using Services.Contracts;
using System.Security.Claims;

namespace BlogManagement.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class BlogController : Controller
    {
        private readonly IService _service;
        public BlogController(IService service)
        {
            _service = service;
        }


        [Authorize]

        public IActionResult Index()
        {

            var allBlogs = _service.BlogService.GetAllBlogs(false);
            return View(allBlogs);

        }
        [Authorize]


        public IActionResult Get([FromRoute(Name = "id")] int id)
        {
            var model = _service.BlogService.GetOneBlog(id, false);

            var comments = _service.CommentService.GetCommentsByBlog(id, false); // Bloga ait yorumlar

            if (comments == null)
            {
                ViewBag.CommentCount = 0;
            }
            else
            {
                ViewBag.CommentCount = model.Comments.Count;
            }

            return View(model);
        }

        [Authorize]
        public IActionResult Create()
        {

            ViewBag.Categories = GetCategoriesSelectList();
            return View();
        }

        //Seçilebilir liste
        private List<SelectListItem> GetCategoriesSelectList()
        {
            return _service.CategoryService
                .GetAllCategories(false)
                .Select(x => new SelectListItem
                {
                    Value = x.CategoryID.ToString(),
                    Text = x.CategoryName
                }).ToList();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public IActionResult Create([FromForm] Blog blog)
        {
            if (ModelState.IsValid)
            {
                _service.BlogService.CreateBlog(blog);
                TempData["success"] = $"Başarıyla eklendi! {blog}";

                return RedirectToAction("Index");
            }
            return View();
        }

      

        [Authorize]
        public IActionResult Update([FromRoute(Name = "id")] int id)
        {
            var model = _service.BlogService.GetOneBlog(id, false);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public IActionResult Update(Blog model)
        {

            if (ModelState.IsValid)
            {
                _service.BlogService.UpdateOneBlog(model);
                TempData["success"] = $"Başarıyla güncellendi! {model}";
                return RedirectToAction("Index");
            }
            return View();
        }


        [HttpGet]
        [Authorize]
        public IActionResult Delete([FromRoute(Name = "id")] int id)
        {
            _service.BlogService.DeleteOneBlog(id);
       
            TempData["danger"] = $"Başarıyla silindi!";

            return RedirectToAction("Index");
        }




    }
}
