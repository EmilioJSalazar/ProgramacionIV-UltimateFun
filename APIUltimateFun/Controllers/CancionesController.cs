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
using APIUltimateFun.Models;

namespace APIUltimateFun.Controllers
{
    public class CancionesController : ApiController
    {
        private ModelEntretenimiento db = new ModelEntretenimiento();

        // GET: api/Canciones
        public IQueryable<Cancion> GetCancions()
        {
            return db.Cancions;
        }

        // GET: api/Canciones/5
        [ResponseType(typeof(Cancion))]
        public IHttpActionResult GetCancion(int id)
        {
            Cancion cancion = db.Cancions.Find(id);
            if (cancion == null)
            {
                return NotFound();
            }

            return Ok(cancion);
        }

        // PUT: api/Canciones/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCancion(int id, Cancion cancion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cancion.CancionID)
            {
                return BadRequest();
            }

            db.Entry(cancion).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CancionExists(id))
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

        // POST: api/Canciones
        [ResponseType(typeof(Cancion))]
        public IHttpActionResult PostCancion(Cancion cancion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Cancions.Add(cancion);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = cancion.CancionID }, cancion);
        }

        // DELETE: api/Canciones/5
        [ResponseType(typeof(Cancion))]
        public IHttpActionResult DeleteCancion(int id)
        {
            Cancion cancion = db.Cancions.Find(id);
            if (cancion == null)
            {
                return NotFound();
            }

            db.Cancions.Remove(cancion);
            db.SaveChanges();

            return Ok(cancion);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CancionExists(int id)
        {
            return db.Cancions.Count(e => e.CancionID == id) > 0;
        }
    }
}