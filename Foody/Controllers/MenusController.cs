using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FoodyResponsitory;
using FoodyDomain;
using FoodyDomain.Model;

namespace Foody.Controllers
{
    public class MenusController : Controller
    {
        private IResponsitory<MenuEntity> _menuResponsitory;

        public MenusController(IResponsitory<MenuEntity> menuResponsitory)
        {
            _menuResponsitory = menuResponsitory;
        }

        // GET: Menus
        public async Task<ActionResult> Index()
        {
            return View(await _menuResponsitory.ToListAsync());
        }

        // GET: Menus/Details/5
        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MenuEntity menu = await _menuResponsitory.FindAsync(id);
            if (menu == null)
            {
                return HttpNotFound();
            }
            return View(menu);
        }

        // GET: Menus/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Menus/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Name,Description,Price,ImageUrl")] MenuEntity menu)
        {
            if (ModelState.IsValid)
            {
                
                await _menuResponsitory.AddAsync(menu);
                return RedirectToAction("Index");
            }

            return View(menu);
        }

        public async Task<PartialViewResult> _MenuPartial()
        {
            var menus = await _menuResponsitory.ToListAsync();
            return PartialView("_MenuPartial", menus);
        }

        [HttpPost]
        public async Task<ActionResult> SearchMenuName(string menuName)
        {
            var menus = await _menuResponsitory.ToListAsync();
            return View("_MenuPartial", menus.Where(s => s.Name.ToLower().Contains(menuName.ToLower())).ToList());
        }

        //// GET: Menus/Edit/5
        //public async Task<ActionResult> Edit(string id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Menu menu = await db.Menus.FindAsync(id);
        //    if (menu == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(menu);
        //}

        //// POST: Menus/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> Edit([Bind(Include = "Id,Name,Description,Price,ImageUrl")] Menu menu)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(menu).State = EntityState.Modified;
        //        await db.SaveChangesAsync();
        //        return RedirectToAction("Index");
        //    }
        //    return View(menu);
        //}

        //// GET: Menus/Delete/5
        //public async Task<ActionResult> Delete(string id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Menu menu = await db.Menus.FindAsync(id);
        //    if (menu == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(menu);
        //}

        //// POST: Menus/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> DeleteConfirmed(string id)
        //{
        //    Menu menu = await db.Menus.FindAsync(id);
        //    db.Menus.Remove(menu);
        //    await db.SaveChangesAsync();
        //    return RedirectToAction("Index");
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
