using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ASPNETExample.Data;
using ASPNETExample.Models;
using System.Data.Entity;

namespace ASPNETExample.Controllers
{
    public class CatalogItemsController : Controller
    {
        private ASPNETExampleContext db = new ASPNETExampleContext();

        // GET: CatalogItems
        public async Task<ActionResult> Index()
        {
            return View(await db.CatalogItems.ToListAsync());
        }

        // GET: CatalogItems/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CatalogItem catalogItem = await db.CatalogItems.FindAsync(id);
            if (catalogItem == null)
            {
                return HttpNotFound();
            }
            return View(catalogItem);
        }

        // GET: CatalogItems/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CatalogItems/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CatalogItem catalogItem)
        {
            if (ModelState.IsValid)
            {
                db.CatalogItems.Add(catalogItem);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(catalogItem);
        }

        // GET: CatalogItems/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CatalogItem catalogItem = await db.CatalogItems.FindAsync(id);
            if (catalogItem == null)
            {
                return HttpNotFound();
            }
            return View(catalogItem);
        }

        // POST: CatalogItems/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(CatalogItem catalogItem)
        {
            if (ModelState.IsValid)
            {
                db.Entry(catalogItem).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(catalogItem);
        }

        // GET: CatalogItems/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CatalogItem catalogItem = await db.CatalogItems.FindAsync(id);
            if (catalogItem == null)
            {
                return HttpNotFound();
            }
            return View(catalogItem);
        }

        // POST: CatalogItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            CatalogItem catalogItem = await db.CatalogItems.FindAsync(id);
            db.CatalogItems.Remove(catalogItem);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
