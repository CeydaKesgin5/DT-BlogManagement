using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services.Contracts;
using System.Runtime.CompilerServices;
using System.Security.Claims;

namespace BlogManagement.Pages
{
    public class ProfileModel : PageModel
    {

        private readonly IServiceManager _manager;
        private readonly UserManager<IdentityUser> _userManager;

        public ProfileModel(IServiceManager manager, UserManager<IdentityUser> userManager)
        {
            _manager = manager;
            _userManager = userManager;
        }

        public IdentityUser Users;
        public async Task<IActionResult> OnGet(string userId)
        {
            ViewData["ActiveTab"] = "Info";
            var user = await _userManager.GetUserAsync(User);
            if (user != null)
            {
                Users = user;
            }
            return Page();
        }


    }
}
