﻿using Microsoft.AspNetCore.Mvc;

namespace HaftalikGorev.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MainController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
