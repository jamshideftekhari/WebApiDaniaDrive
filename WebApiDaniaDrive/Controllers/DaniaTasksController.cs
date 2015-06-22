using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WebApiDaniaDrive.Models;

namespace WebApiDaniaDrive.Controllers
{
    public class DaniaTasksController : ApiController
    {
        private WebApiDaniaDriveDbContext db = new WebApiDaniaDriveDbContext();

        // GET: api/DaniaTasks
        public IQueryable<DaniaTask> GetDaniaTasks()
        {
            return db.DaniaTasks;
        }

        // GET: api/DaniaTasks/5
        [ResponseType(typeof(DaniaTask))]
        public IHttpActionResult GetDaniaTask(int id)
        {
            DaniaTask daniaTask = db.DaniaTasks.Find(id);
            if (daniaTask == null)
            {
                return NotFound();
            }

            return Ok(daniaTask);
        }

        // PUT: api/DaniaTasks/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDaniaTask(int id, DaniaTask daniaTask)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != daniaTask.DaniaTaskId)
            {
                return BadRequest();
            }

            db.Entry(daniaTask).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DaniaTaskExists(id))
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

        // POST: api/DaniaTasks
        [ResponseType(typeof(DaniaTask))]
        public IHttpActionResult PostDaniaTask(DaniaTask daniaTask)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.DaniaTasks.Add(daniaTask);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = daniaTask.DaniaTaskId }, daniaTask);
        }

        // DELETE: api/DaniaTasks/5
        [ResponseType(typeof(DaniaTask))]
        public IHttpActionResult DeleteDaniaTask(int id)
        {
            DaniaTask daniaTask = db.DaniaTasks.Find(id);
            if (daniaTask == null)
            {
                return NotFound();
            }

            db.DaniaTasks.Remove(daniaTask);
            db.SaveChanges();

            return Ok(daniaTask);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DaniaTaskExists(int id)
        {
            return db.DaniaTasks.Count(e => e.DaniaTaskId == id) > 0;
        }
    }
}