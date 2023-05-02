using HaftalikGorev.Data;
using HaftalikGorev.Entities;
using HaftalikGorev.Tools;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HaftalikGorev.Areas.Admin.Controllers
{
    [Area("Admin"),Authorize]
    public class SliderController : Controller
    {
        private readonly Databasecontext _databaseContext;

        public SliderController(Databasecontext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        // GET: SliderController
        public ActionResult Index()
        {
            return View(_databaseContext.Sliders.ToList());
        }

        // GET: SliderController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SliderController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SliderController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Slider collection, IFormFile? Image)
        {
            try
            {
                collection.Image = await FileLoader.FileLoaderAsync(Image);
                await _databaseContext.Sliders.AddAsync(collection);
                await _databaseContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SliderController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_databaseContext.Sliders.Find(id));
        }

        // POST: SliderController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, Slider collection, IFormFile? Image)
        {
            try
            {
                if (Image is not null)
                {
                    collection.Image = await FileLoader.FileLoaderAsync(Image);
                }
                _databaseContext.Sliders.Update(collection);
                await _databaseContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SliderController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_databaseContext.Sliders.Find(id));
        }

        // POST: SliderController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Slider collection)
        {
            try
            {
                _databaseContext.Sliders.Remove(collection);
                _databaseContext.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
