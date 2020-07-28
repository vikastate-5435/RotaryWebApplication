using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using EntityModel;

namespace RotaryWebApplication.Controllers
{
    public class BasketMasterController : ApiController
    {
        private RotaryDbContext db = new RotaryDbContext();

        // GET: api/BasketMaster
        public IQueryable<ProductMaster> GetProducts()
        {
            return db.Products;
        }

        // GET: api/BasketMaster/5
        [ResponseType(typeof(ProductMaster))]
        public async Task<IHttpActionResult> GetProductMaster(int id)
        {
            ProductMaster productMaster = await db.Products.FindAsync(id);
            if (productMaster == null)
            {
                return NotFound();
            }

            return Ok(productMaster);
        }

        // PUT: api/BasketMaster/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutProductMaster(int id, ProductMaster productMaster)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != productMaster.ProductID)
            {
                return BadRequest();
            }

            db.Entry(productMaster).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductMasterExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/BasketMaster
        [ResponseType(typeof(ProductMaster))]
        public async Task<IHttpActionResult> PostProductMaster(ProductMaster productMaster)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Products.Add(productMaster);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = productMaster.ProductID }, productMaster);
        }

        // DELETE: api/BasketMaster/5
        [ResponseType(typeof(ProductMaster))]
        public async Task<IHttpActionResult> DeleteProductMaster(int id)
        {
            ProductMaster productMaster = await db.Products.FindAsync(id);
            if (productMaster == null)
            {
                return NotFound();
            }

            db.Products.Remove(productMaster);
            await db.SaveChangesAsync();

            return Ok(productMaster);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProductMasterExists(int id)
        {
            return db.Products.Count(e => e.ProductID == id) > 0;
        }
    }
}