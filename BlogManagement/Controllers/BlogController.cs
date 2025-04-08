using Entities.DTOs.BlogDTOs;
using Entities.Models;
using BlogManagement.Services;
using Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BlogManagement.Controllers
{
    [Authorize]
    public class BlogController : Controller
    {
        private readonly IService _blogService;

        public BlogController(IService blogService)
        {
            _blogService = blogService;
        }

        [AllowAnonymous]
        public IActionResult Get([FromRoute(Name = "id")] int id)
        {
            var model = _blogService.BlogService.GetOneBlog(id, false);
            return View(model);
        }
        [AllowAnonymous]

        public IActionResult Index()
        {
            var model = _blogService.BlogService.GetAllBlogs(false);
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
        //    return new SelectList(_blogService.CategoryService.GetAllCategories(false), //veri tabanındaki kayıtlar item
        //     "CategoryID", //veri alanı
        //     "CategoryName", //text alanı
        //     "1"); //default olarak idsi 1 olan gelecek 
        //}

        private List<SelectListItem> GetCategoriesSelectList()
        {
            return _blogService.CategoryService
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
        public IActionResult Create([FromForm] Blog product)
        {
            if (ModelState.IsValid)
            {
                _blogService.BlogService.CreateBlog(product);
                return RedirectToAction("Index");
            }
            return View();
        }
        [Authorize]
        public IActionResult Update([FromRoute(Name = "id")] int id)
        {
            var model = _blogService.BlogService.GetOneBlog(id, false);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public IActionResult Update(Blog product)
        {
            if (ModelState.IsValid)
            {
                _blogService.BlogService.UpdateOneBlog(product);
                return RedirectToAction("Index");
            }
            return View();
        }


        [HttpGet]
        [Authorize]
        public IActionResult Delete([FromRoute(Name = "id")] int id)
        {
            _blogService.BlogService.DeleteOneBlog(id);
            return RedirectToAction("Index");
        }


    }
}
