using Entities.DTOs.BlogDTOs;
using Entities.Models;
using BlogManagement.Services;
using Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Services;
using Repositories;
using BlogManagement.Models;
using Entities.RequestParameters;
using System.Reflection.Metadata;
using System.Security.Claims;

namespace BlogManagement.Controllers
{
    [Authorize]
    public class BlogController : Controller
    {
        private readonly IService _service;
        private readonly IBlogService _blogService;
        private readonly AppDbContext _context;
        public BlogController(IService service, IBlogService blogService, AppDbContext context)
        {
            _service = service;
            _blogService = blogService;
            _context = context;
        }

        [AllowAnonymous]
        public IActionResult Get([FromRoute(Name = "id")] int id)
        {
            var model = _blogService.GetOneBlog(id, false);

            model.Comments = _context.Comments.Where(c => c.BlogId == id).ToList(); // Bloga ait yorumları al

            if (model.Comments == null)
            {
                ViewBag.CommentCount = 0;
            }
            else
            {
                ViewBag.CommentCount = model.Comments.Count; 
            }

            return View(model);
        }


    

        [AllowAnonymous]

        //public IActionResult Index()
        //{
        //    var model = _service.BlogService.GetAllBlogs(false);
        //    return View(model);


        //}

        //[HttpGet]
        //public IActionResult GetBlogsLatest( string sortOrder)
        //{
        //    ViewBag.SortOrder = sortOrder;
        //    var allBlogs = _service.BlogService.GetAllBlogs(false);
        //    if (sortOrder == "date")
        //    { 
        //        allBlogs= allBlogs.OrderByDescending(b=>b.PublishedAt).ToList();
        //    }
        //    return View(allBlogs);
        //}

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
            //Seçilebilir bir liste tanımı
            ViewBag.Categories = GetCategoriesSelectList();
            return View();
        }


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
        public IActionResult Update(Blog comment)
        {

            if (ModelState.IsValid)
            {
                _service.BlogService.UpdateOneBlog(comment); 
                TempData["success"] = $"Başarıyla güncellendi! {model}";
                return RedirectToAction("Index");
            }
            return View();
        }


        [HttpGet]
        [Authorize]
        public IActionResult Delete([FromRoute(Name = "id")] int id)
        {
            var model = _service.BlogService.GetOneBlog(id, false);
            _service.BlogService.DeleteOneBlog(id);
            var currentUserId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (model.UserId != currentUserId)
            {
                return RedirectToAction("AccessDenied", "Account");
            }
            TempData["danger"] = $"Başarıyla silindi! {model}";

            return RedirectToAction("Index");
        }


    }
}
