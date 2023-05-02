using HaftalikGorev.Data;
using HaftalikGorev.Entities;
using HaftalikGorev.Tools;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace HaftalikGorev.Areas.Admin.Controllers
{
    [Area("Admin"),Authorize]
    public class ProductsController : Controller
    {
        private readonly Databasecontext _databasecontext;

        public ProductsController(Databasecontext databasecontext)
        {
            _databasecontext = databasecontext;
        }

        // GET: ProductsController
        public ActionResult Index()
        {
            return View(_databasecontext.Products.Include(c => c.Category).ToList());
        }

        // GET: ProductsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ProductsController/Create
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(_databasecontext.Categories.ToList(), "Name", "Name");
            return View();
        }

        // POST: ProductsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Product collection, IFormFile? Image)
        {
            try
            {
                collection.Image= await FileLoader.FileLoaderAsync(Image);
                await _databasecontext.Products.AddAsync(collection);
                await _databasecontext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ViewBag.CategoryId = new SelectList(_databasecontext.Categories.ToList(), "Id", "Name");
                return View();
            }
        }

        // GET: ProductsController/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.CategoryId = new SelectList(_databasecontext.Categories.ToList(), "Id", "Name");
            return View(_databasecontext.Products.Find(id));
        }

        // POST: ProductsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, Product collection, IFormFile? Image)
        {
            try
            {
                if (Image is not null)
                {
                    collection.Image = await FileLoader.FileLoaderAsync(Image);
                }
                
                _databasecontext.Products.Update(collection);
                await _databasecontext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ViewBag.CategoryId = new SelectList(_databasecontext.Categories.ToList(), "Id", "Name");
                return View();
            }
        }

        // GET: ProductsController/Delete/5
        public ActionResult Delete(int id)
        {            
            return View(_databasecontext.Products.Find(id));
        }

        // POST: ProductsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Product collection)
        {
            try
            {
                _databasecontext.Products.Remove(collection);
                _databasecontext.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ViewBag.CategoryId = new SelectList(_databasecontext.Categories.ToList(), "Id", "Name");
                return View();
            }
        }
    }
}
