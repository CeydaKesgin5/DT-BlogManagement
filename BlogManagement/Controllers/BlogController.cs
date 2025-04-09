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

            // Yorumları al
            model.Comments = _context.Comments.Where(c => c.BlogId == id).ToList(); // Bloga ait yorumları al

            // Debugging için yorumların sayısını kontrol et
            if (model.Comments == null)
            {
                // Yorum listesi null ise
                ViewBag.CommentCount = 0; // Değişken ile bilgi ver
            }
            else
            {
                ViewBag.CommentCount = model.Comments.Count; // Yorum sayısını değişkene ata
            }

            return View(model);
        }
        [AllowAnonymous]

        public IActionResult Index()
        {
            var model = _service.BlogService.GetAllBlogs(false);
            return View(model);


        }
        [Authorize]
        public IActionResult Create()
        {
            //Seçilebilir bir liste tanımı
            ViewBag.Categories = GetCategoriesSelectList();
            return View();
        }



      
        //private SelectList GetCategoriesSelectList()
        //{
        //    return new SelectList(_service.CategoryService.GetAllCategories(false), //veri tabanındaki kayıtlar item
        //     "CategoryID", //veri alanı
        //     "CategoryName", //text alanı
        //     "1"); //default olarak idsi 1 olan gelecek 
        //}

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
        public IActionResult Update(Blog comment)
        {
            if (ModelState.IsValid)
            {
                _service.BlogService.UpdateOneBlog(comment);
                return RedirectToAction("Index");
            }
            return View();
        }


        [HttpGet]
        [Authorize]
        public IActionResult Delete([FromRoute(Name = "id")] int id)
        {
            _service.BlogService.DeleteOneBlog(id);
            return RedirectToAction("Index");
        }


    }
}
