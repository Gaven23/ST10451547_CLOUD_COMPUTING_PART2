﻿using Microsoft.AspNetCore.Mvc;

namespace ST10451547_CLOUD_COMPUTING_PART2.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
