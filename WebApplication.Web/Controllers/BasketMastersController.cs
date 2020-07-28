using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EntityModel;

namespace WebApplication.Web.Controllers
{
    public class BasketMastersController : Controller
    {
        private RotaryDbContext db = new RotaryDbContext();

        // GET: BasketMasters
        public async Task<ActionResult> Index()
        {
            return View(await db.BasketMasters.ToListAsync());
        }

        // GET: BasketMasters/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BasketMaster basketMaster = await db.BasketMasters.FindAsync(id);
            if (basketMaster == null)
            {
                return HttpNotFound();
            }
            return View(basketMaster);
        }

        // GET: BasketMasters/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BasketMasters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "BasketID,BasketName,SKUID")] BasketMaster basketMaster)
        {
            if (ModelState.IsValid)
            {
                db.BasketMasters.Add(basketMaster);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(basketMaster);
        }

        // GET: BasketMasters/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BasketMaster basketMaster = await db.BasketMasters.FindAsync(id);
            if (basketMaster == null)
            {
                return HttpNotFound();
            }
            return View(basketMaster);
        }

        // POST: BasketMasters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "BasketID,BasketName,SKUID")] BasketMaster basketMaster)
        {
            if (ModelState.IsValid)
            {
                db.Entry(basketMaster).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(basketMaster);
        }

        // GET: BasketMasters/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BasketMaster basketMaster = await db.BasketMasters.FindAsync(id);
            if (basketMaster == null)
            {
                return HttpNotFound();
            }
            return View(basketMaster);
        }

        // POST: BasketMasters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            BasketMaster basketMaster = await db.BasketMasters.FindAsync(id);
            db.BasketMasters.Remove(basketMaster);
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
