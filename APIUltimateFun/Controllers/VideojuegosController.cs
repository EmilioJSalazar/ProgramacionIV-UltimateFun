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
    public class VideojuegosController : ApiController
    {
        private ModelEntretenimiento db = new ModelEntretenimiento();

        // GET: api/Videojuegos
        public IQueryable<Videojuego> GetVideojuegoes()
        {
            return db.Videojuegoes;
        }

        // GET: api/Videojuegos/5
        [ResponseType(typeof(Videojuego))]
        public IHttpActionResult GetVideojuego(int id)
        {
            Videojuego videojuego = db.Videojuegoes.Find(id);
            if (videojuego == null)
            {
                return NotFound();
            }

            return Ok(videojuego);
        }

        // PUT: api/Videojuegos/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutVideojuego(int id, Videojuego videojuego)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != videojuego.VideojuegoID)
            {
                return BadRequest();
            }

            db.Entry(videojuego).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VideojuegoExists(id))
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

        // POST: api/Videojuegos
        [ResponseType(typeof(Videojuego))]
        public IHttpActionResult PostVideojuego(Videojuego videojuego)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Videojuegoes.Add(videojuego);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = videojuego.VideojuegoID }, videojuego);
        }

        // DELETE: api/Videojuegos/5
        [ResponseType(typeof(Videojuego))]
        public IHttpActionResult DeleteVideojuego(int id)
        {
            Videojuego videojuego = db.Videojuegoes.Find(id);
            if (videojuego == null)
            {
                return NotFound();
            }

            db.Videojuegoes.Remove(videojuego);
            db.SaveChanges();

            return Ok(videojuego);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool VideojuegoExists(int id)
        {
            return db.Videojuegoes.Count(e => e.VideojuegoID == id) > 0;
        }
    }
}