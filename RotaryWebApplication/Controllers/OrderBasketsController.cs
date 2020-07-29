﻿using System;
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
    public class OrderBasketsController : ApiController
    {
        private RotaryDbContext db = new RotaryDbContext();

        // GET: api/OrderBaskets
        public IQueryable<OrderBasket> GetOrderBaskets()
        {
            return db.OrderBaskets.Include(b=>b.BasketMasters);
        }



        // GET: api/OrderBaskets/5
        [ResponseType(typeof(OrderBasket))]
        public async Task<IHttpActionResult> GetOrderBasket(int id)
        {
            OrderBasket orderBasket = await db.OrderBaskets.FindAsync(id);
            if (orderBasket == null)
            {
                return NotFound();
            }

            return Ok(orderBasket);
        }

        // PUT: api/OrderBaskets/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutOrderBasket(int id, OrderBasket orderBasket)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != orderBasket.OrderId)
            {
                return BadRequest();
            }

            db.Entry(orderBasket).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderBasketExists(id))
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

        // POST: api/OrderBaskets
        [ResponseType(typeof(OrderBasket))]
        public async Task<IHttpActionResult> PostOrderBasket(OrderBasket orderBasket)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.OrderBaskets.Add(orderBasket);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = orderBasket.OrderId }, orderBasket);
        }

        // DELETE: api/OrderBaskets/5
        [ResponseType(typeof(OrderBasket))]
        public async Task<IHttpActionResult> DeleteOrderBasket(int id)
        {
            OrderBasket orderBasket = await db.OrderBaskets.FindAsync(id);
            if (orderBasket == null)
            {
                return NotFound();
            }

            db.OrderBaskets.Remove(orderBasket);
            await db.SaveChangesAsync();

            return Ok(orderBasket);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool OrderBasketExists(int id)
        {
            return db.OrderBaskets.Count(e => e.OrderId == id) > 0;
        }
    }
}