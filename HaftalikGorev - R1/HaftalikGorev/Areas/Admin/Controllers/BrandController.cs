using HaftalikGorev.Data;
using HaftalikGorev.Entities;
using HaftalikGorev.Tools;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage;

namespace HaftalikGorev.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BrandController : Controller
    {
        private readonly Databasecontext _databasecontext;

        public BrandController(Databasecontext databasecontext)
        {
            _databasecontext = databasecontext;
        }

        // GET: BrandController
        public ActionResult Index()
        {
            return View(_databasecontext.Brands.ToList());
        }

        // GET: BrandController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: BrandController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BrandController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Brand collection, IFormFile? Logo)
        {
            try
            {
                collection.Logo= await FileLoader.FileLoaderAsync(Logo);
                await _databasecontext.Brands.AddAsync(collection);
                await _databasecontext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: BrandController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_databasecontext.Brands.Find(id));
        }

        // POST: BrandController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, Brand collection, IFormFile? Logo)
        {
            try
            {
                if (Logo is not null)
                {
                    collection.Logo = await FileLoader.FileLoaderAsync(Logo);
                }
                _databasecontext.Brands.Update(collection);
                await _databasecontext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: BrandController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_databasecontext.Brands.Find(id));
        }

        // POST: BrandController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Brand collection)
        {
            try
            {
                _databasecontext.Brands.Remove(collection);
                _databasecontext.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
