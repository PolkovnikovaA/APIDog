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
using API.Entites;
using API.Models;

namespace API.Controllers
{
    public class DogsController : ApiController
    {
        private DogsEntities db = new DogsEntities();

        // GET: api/Dogs
        [ResponseType(typeof(List<DogModel>))]
        public IHttpActionResult GetDog()
        {
            return Ok(db.Dog.ToList().ConvertAll(x => new DogModel(x)));
        }

        // GET: api/Dogs/5
        [ResponseType(typeof(Dog))]
        public IHttpActionResult GetDog(int id)
        {
            Dog dog = db.Dog.Find(id);
            if (dog == null)
            {
                return NotFound();
            }

            return Ok(dog);
        }

        // PUT: api/Dogs/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDog(int id, Dog dog)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != dog.Id)
            {
                return BadRequest();
            }

            db.Entry(dog).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DogExists(id))
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

        // POST: api/Dogs
        [ResponseType(typeof(Dog))]
        public IHttpActionResult PostDog(Dog dog)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Dog.Add(dog);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = dog.Id }, dog);
        }

        // DELETE: api/Dogs/5
        [ResponseType(typeof(Dog))]
        public IHttpActionResult DeleteDog(int id)
        {
            Dog dog = db.Dog.Find(id);
            if (dog == null)
            {
                return NotFound();
            }

            db.Dog.Remove(dog);
            db.SaveChanges();

            return Ok(dog);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DogExists(int id)
        {
            return db.Dog.Count(e => e.Id == id) > 0;
        }
    }
}