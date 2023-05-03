using HaftalikGorev.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HaftalikGorev.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly Databasecontext _databaseContext;

        public CategoriesController(Databasecontext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public IActionResult Index(int? id)
        {
            if (id==null)
            {
                return BadRequest();
            }
            var categories = _databaseContext.Categories.Include(p => p.Products).FirstOrDefault(c => c.Id == id);
            if (categories==null) 
            {
                return NotFound();
            }
            return View(categories);
        }
    }
}
