﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace BlogManagement.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]

    public class RoleController : Controller
    {
        private readonly IService _manager;

        public RoleController(IService manager)
        {
            _manager = manager;
        }

        public IActionResult Index()
        {
            return View(_manager.AuthService.Roles);
        }
    }
}
