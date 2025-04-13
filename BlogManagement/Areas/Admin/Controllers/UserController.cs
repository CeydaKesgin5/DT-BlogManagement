using Entities.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Services.Contracts;

namespace BlogManagement.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class UserController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UserController(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        // List Users
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var users = _userManager.Users.ToList();
            return View(users);
        }

        // Create User
        public IActionResult Create()
        {
            return View();
        }
        //private readonly IService _service;
        //public UserController(IService service)
        //{
        //    _service = service;
        //}


        //[Authorize]

        //public IActionResult Index()
        //{

        //    var allUsers = _service.UserService.GetAllUsers(false);
        //    return View(allUsers);

        //}
        //[Authorize]
        //public IActionResult Create()
        //{

        //    return View();
        //}



        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //[Authorize]
        //public IActionResult Create([FromForm] User User)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _service.UserService.CreateUser(User);
        //        TempData["success"] = $"Başarıyla eklendi! {User}";

        //        return RedirectToAction("Index");
        //    }
        //    return View();
        //}



        //[Authorize]
        //public IActionResult Update([FromRoute(Name = "id")] string id)
        //{
        //    var model = _service.UserService.GetOneUser(id, false);

        //    return View(model);
        //}

        ////[HttpPost]
        ////[ValidateAntiForgeryToken]
        ////[Authorize]
        ////public IActionResult Update(User model)
        ////{

        ////    if (ModelState.IsValid)
        ////    {
        ////        _service.UserService.UpdateOneUser(model);
        ////        TempData["success"] = $"Başarıyla güncellendi! {model}";
        ////        return RedirectToAction("Index");
        ////    }
        ////    return View();
        ////}


        //[HttpGet]
        //[Authorize]
        //public IActionResult Delete([FromRoute(Name = "id")] string id)
        //{
        //    _service.UserService.DeleteOneUser(id);

        //    TempData["danger"] = $"Başarıyla silindi!";

        //    return RedirectToAction("Index");
        //}


    }
}
