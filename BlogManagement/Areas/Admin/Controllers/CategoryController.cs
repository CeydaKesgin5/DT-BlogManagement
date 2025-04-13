using BlogManagement.Services;
using Entities.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace BlogManagement.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class CategoryController:Controller
    {
        private readonly IService _service;
        
        public CategoryController(IService service)
        {
            _service = service;
        }


        [Authorize]

        public IActionResult Index()
        {

            var allBlogs = _service.CategoryService.GetCategoriesWithBlogs(false);
            ViewBag.ShowForm = true;

            return View(allBlogs);

        }

        [Authorize]
        public IActionResult Create([FromForm] Category category)
        {

            if (ModelState.IsValid)
            {
                _service.CategoryService.CreateCategory(category);
                return RedirectToAction("Index");
            }

            //ViewBag.ShowForm = true; // Hatalıysa formu açık tut
            return View("Index");
        }

        [HttpGet]
        [Authorize]
        public IActionResult Delete([FromRoute(Name = "id")] int id)
        {

            _service.CategoryService.DeleteOneCategory(id);

            TempData["danger"] = $"Başarıyla silindi!";

            return RedirectToAction("Index");
        }


    }
}
