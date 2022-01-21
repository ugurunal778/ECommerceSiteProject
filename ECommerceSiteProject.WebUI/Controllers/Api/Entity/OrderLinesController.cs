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
using DAL.Entity;

namespace ECommerceSiteProject.WebUI.Controllers.Api.Entity
{
    public class OrderLinesController : ApiController
    {
        private DataContext db = new DataContext();

        // GET: api/OrderLines
        public IQueryable<OrderLine> GetOrderLines()
        {
            return db.OrderLines;
        }

        // GET: api/OrderLines/5
        [ResponseType(typeof(OrderLine))]
        public async Task<IHttpActionResult> GetOrderLine(int id)
        {
            OrderLine orderLine = await db.OrderLines.FindAsync(id);
            if (orderLine == null)
            {
                return NotFound();
            }

            return Ok(orderLine);
        }

        // PUT: api/OrderLines/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutOrderLine(int id, OrderLine orderLine)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != orderLine.Id)
            {
                return BadRequest();
            }

            db.Entry(orderLine).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderLineExists(id))
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

        // POST: api/OrderLines
        [ResponseType(typeof(OrderLine))]
        public async Task<IHttpActionResult> PostOrderLine(OrderLine orderLine)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.OrderLines.Add(orderLine);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = orderLine.Id }, orderLine);
        }

        // DELETE: api/OrderLines/5
        [ResponseType(typeof(OrderLine))]
        public async Task<IHttpActionResult> DeleteOrderLine(int id)
        {
            OrderLine orderLine = await db.OrderLines.FindAsync(id);
            if (orderLine == null)
            {
                return NotFound();
            }

            db.OrderLines.Remove(orderLine);
            await db.SaveChangesAsync();

            return Ok(orderLine);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool OrderLineExists(int id)
        {
            return db.OrderLines.Count(e => e.Id == id) > 0;
        }
    }
}