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
    public class OrderBasketsController : Controller
    {
        private RotaryDbContext db = new RotaryDbContext();

        // GET: OrderBaskets
        public async Task<ActionResult> Index()
        {
            return View(await db.OrderBaskets.ToListAsync());
        }

        // GET: OrderBaskets/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderBasket orderBasket = await db.OrderBaskets.FindAsync(id);
            if (orderBasket == null)
            {
                return HttpNotFound();
            }
            return View(orderBasket);
        }

        // GET: OrderBaskets/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OrderBaskets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "OrderId,BasketID,BasketName,SKUID,OrderDate,OrderBy")] OrderBasket orderBasket)
        {
            if (ModelState.IsValid)
            {
                db.OrderBaskets.Add(orderBasket);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(orderBasket);
        }

        // GET: OrderBaskets/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderBasket orderBasket = await db.OrderBaskets.FindAsync(id);
            if (orderBasket == null)
            {
                return HttpNotFound();
            }
            return View(orderBasket);
        }

        // POST: OrderBaskets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "OrderId,BasketID,BasketName,SKUID,OrderDate,OrderBy")] OrderBasket orderBasket)
        {
            if (ModelState.IsValid)
            {
                db.Entry(orderBasket).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(orderBasket);
        }

        // GET: OrderBaskets/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderBasket orderBasket = await db.OrderBaskets.FindAsync(id);
            if (orderBasket == null)
            {
                return HttpNotFound();
            }
            return View(orderBasket);
        }

        // POST: OrderBaskets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            OrderBasket orderBasket = await db.OrderBaskets.FindAsync(id);
            db.OrderBaskets.Remove(orderBasket);
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
