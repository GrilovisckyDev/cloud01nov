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
using Trabalho1AspNet.Models;
using Trabalho1AspNet.Models.Contexto;

namespace Trabalho1AspNet.WebAPI
{
    public class Class1Controller : ApiController
    {
        private Contexto db = new Contexto();

        // GET: api/Class1
        public IQueryable<Class1> GetClass1()
        {
            return db.Class1;
        }

        // GET: api/Class1/5
        [ResponseType(typeof(Class1))]
        public IHttpActionResult GetClass1(int id)
        {
            Class1 class1 = db.Class1.Find(id);
            if (class1 == null)
            {
                return NotFound();
            }

            return Ok(class1);
        }

        // PUT: api/Class1/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutClass1(int id, Class1 class1)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != class1.ID)
            {
                return BadRequest();
            }

            db.Entry(class1).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Class1Exists(id))
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

        // POST: api/Class1
        [ResponseType(typeof(Class1))]
        public IHttpActionResult PostClass1(Class1 class1)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Class1.Add(class1);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = class1.ID }, class1);
        }

        // DELETE: api/Class1/5
        [ResponseType(typeof(Class1))]
        public IHttpActionResult DeleteClass1(int id)
        {
            Class1 class1 = db.Class1.Find(id);
            if (class1 == null)
            {
                return NotFound();
            }

            db.Class1.Remove(class1);
            db.SaveChanges();

            return Ok(class1);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Class1Exists(int id)
        {
            return db.Class1.Count(e => e.ID == id) > 0;
        }
    }
}