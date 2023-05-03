using HaftalikGorev.Data;
using HaftalikGorev.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace HaftalikGorev.Controllers
{
    public class HomeController : Controller
    {
        private readonly Databasecontext _databasecontext;

        public HomeController(Databasecontext databasecontext)
        {
            _databasecontext = databasecontext;
        }

        public async Task<IActionResult> IndexAsync()
        {
            var model = new HomePageModel()
            {
                Sliders = _databasecontext.Sliders.ToList(),
                Products = await _databasecontext.Products.ToListAsync()
            };
            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}