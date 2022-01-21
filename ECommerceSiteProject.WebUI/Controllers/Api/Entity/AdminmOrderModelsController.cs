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
using DTO.Models;

namespace ECommerceSiteProject.WebUI.Controllers.Api
{
    public class AdminmOrderModelsController : ApiController
    {
        private DataContext db = new DataContext();

        // GET: api/AdminmOrderModels
        public IQueryable<AdminmOrderModel> GetAdminmOrderModels()
        {
            return db.AdminmOrderModels;
        }

        // GET: api/AdminmOrderModels/5
        [ResponseType(typeof(AdminmOrderModel))]
        public async Task<IHttpActionResult> GetAdminmOrderModel(int id)
        {
            AdminmOrderModel adminmOrderModel = await db.AdminmOrderModels.FindAsync(id);
            if (adminmOrderModel == null)
            {
                return NotFound();
            }

            return Ok(adminmOrderModel);
        }

        // PUT: api/AdminmOrderModels/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutAdminmOrderModel(int id, AdminmOrderModel adminmOrderModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != adminmOrderModel.Id)
            {
                return BadRequest();
            }

            db.Entry(adminmOrderModel).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdminmOrderModelExists(id))
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

        // POST: api/AdminmOrderModels
        [ResponseType(typeof(AdminmOrderModel))]
        public async Task<IHttpActionResult> PostAdminmOrderModel(AdminmOrderModel adminmOrderModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.AdminmOrderModels.Add(adminmOrderModel);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = adminmOrderModel.Id }, adminmOrderModel);
        }

        // DELETE: api/AdminmOrderModels/5
        [ResponseType(typeof(AdminmOrderModel))]
        public async Task<IHttpActionResult> DeleteAdminmOrderModel(int id)
        {
            AdminmOrderModel adminmOrderModel = await db.AdminmOrderModels.FindAsync(id);
            if (adminmOrderModel == null)
            {
                return NotFound();
            }

            db.AdminmOrderModels.Remove(adminmOrderModel);
            await db.SaveChangesAsync();

            return Ok(adminmOrderModel);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AdminmOrderModelExists(int id)
        {
            return db.AdminmOrderModels.Count(e => e.Id == id) > 0;
        }
    }
}