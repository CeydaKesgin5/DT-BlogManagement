using Entities.Models;
using Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;
using System.Runtime.CompilerServices;

namespace BlogManagement.Controllers
{
    [Authorize]
    public class BlogController : Controller
    {
        private readonly IServiceManager _service;
        private readonly IBlogService _blogService;
        public BlogController(IServiceManager service, IBlogService blogService)
        {
            _service = service;
            _blogService = blogService;
        }

        [AllowAnonymous]
        public IActionResult Get([FromRoute(Name = "id")] int id)
        {
            var model = _blogService.GetOneBlog(id, false);

            var comments = _service.CommentService.GetCommentsByBlog(id, false); // Bloga ait yorumlar
            if (comments == null)
            {
                ViewBag.CommentCount = 0;
            }
            else
            {
                ViewBag.CommentCount = model.Comments.Count;
                model.Comments = comments.ToList();

            }

            return View(model);
        }


    

        [AllowAnonymous]

        public IActionResult Index(int? categoryId, string sortOrder)
        {
            ViewBag.SortOrder = sortOrder;

            var allBlogs = _service.BlogService.GetAllBlogs(false);

            
            if (categoryId != null)
            {
                var blogsByCategory = _service.BlogService.GetBlogsByCategory(categoryId.Value, false);
                var category = _service.CategoryService.GetOneCategory((int)categoryId, false);
                ViewBag.CategoryId = categoryId;
                ViewBag.CategoryName = category?.CategoryName;
                return View(blogsByCategory);

            }
            if (sortOrder == "date")
            {
                allBlogs = allBlogs.OrderByDescending(b => b.PublishedAt).ToList();
            }


            return View(allBlogs);

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
      
        public async Task<IActionResult> CreateAsync([FromForm] Blog blog, IFormFile file)
        {
            if (ModelState.IsValid)
            {
                string path = Path.Combine(Directory.GetCurrentDirectory(),
                "wwwroot", "images", file.FileName);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
                blog.Image = String.Concat("/images/", file.FileName);
                _service.BlogService.CreateBlog(blog);
                TempData["success"] = $"Blog has been created.";
                return RedirectToAction("Index");
            }
            return View();
        }




        [Authorize]
        public IActionResult Update([FromRoute(Name = "id")] int id)
        {
            var model = _service.BlogService.GetOneBlog(id, false);

            var currentUserId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (model.UserId != currentUserId)
            {
                return RedirectToAction("AccessDenied", "Account");
            }
           

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
