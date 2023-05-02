using HaftalikGorev.Data;
using HaftalikGorev.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HaftalikGorev.Areas.Admin.Controllers
{
    [Area("Admin"),Authorize]
    public class CategoriesController : Controller
    {
        private readonly Databasecontext _databasecontext;

        public CategoriesController(Databasecontext databasecontext)
        {
            _databasecontext = databasecontext;
        }

        // GET: Categories
        public ActionResult Index()
        {
            return View(_databasecontext.Categories.ToList());
        }

        // GET: Categories/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Categories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Categories/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Category collection)
        {
            try
            {
                _databasecontext.Categories.Add(collection);
                _databasecontext.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Categories/Edit/5
        public ActionResult Edit(int id)
        {         
            return View(_databasecontext.Categories.Find(id));
        }

        // POST: Categories/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Category collection)
        {
            try
            {
                _databasecontext.Categories.Update(collection);
                _databasecontext.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Categories/Delete/5
        public ActionResult Delete(int id)
        {            
            return View(_databasecontext.Categories.Find(id));
        }

        // POST: Categories/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Category collection)
        {
            try
            {
                _databasecontext.Categories.Remove(collection);
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
