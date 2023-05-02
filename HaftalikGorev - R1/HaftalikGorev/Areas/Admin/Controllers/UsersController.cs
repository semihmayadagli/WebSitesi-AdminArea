using HaftalikGorev.Data;
using HaftalikGorev.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HaftalikGorev.Areas.Admin.Controllers
{
    [Area("Admin"),Authorize]
    public class UsersController : Controller
    {
        private readonly Databasecontext _databasecontext;

        public UsersController(Databasecontext databasecontext)
        {
            _databasecontext = databasecontext;
        }

        // GET: UsersController
        public ActionResult Index()
        {
            return View(_databasecontext.Users.ToList());
        }

        // GET: UsersController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UsersController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UsersController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(User collection)
        {
            try
            {
                _databasecontext.Users.Add(collection);
                _databasecontext.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UsersController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_databasecontext.Users.Find(id));
        }

        // POST: UsersController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, User collection)
        {
            try
            {
                _databasecontext.Users.Update(collection);
                _databasecontext.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UsersController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_databasecontext.Users.Find(id));
        }

        // POST: UsersController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, User collection)
        {
            try
            {                
                _databasecontext.Users.Remove(collection);
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
