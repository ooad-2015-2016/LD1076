﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WebAplikacija.Models;

namespace WebAplikacija.Controllers
{
    public class Ispit1Controller : ApiController
    {
        private DataBaze db = new DataBaze();

        // GET: api/Ispit1
        public IQueryable<Ispit> GetIspiti()
        {
            return db.Ispiti;
        }

        // GET: api/Ispit1/5
        [ResponseType(typeof(Ispit))]
        public IHttpActionResult GetIspit(int id)
        {
            Ispit ispit = db.Ispiti.Find(id);
            if (ispit == null)
            {
                return NotFound();
            }

            return Ok(ispit);
        }

        // PUT: api/Ispit1/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutIspit(int id, Ispit ispit)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != ispit.ispitID)
            {
                return BadRequest();
            }

            db.Entry(ispit).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IspitExists(id))
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

        // POST: api/Ispit1
        [ResponseType(typeof(Ispit))]
        public IHttpActionResult PostIspit(Ispit ispit)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Ispiti.Add(ispit);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = ispit.ispitID }, ispit);
        }

        // DELETE: api/Ispit1/5
        [ResponseType(typeof(Ispit))]
        public IHttpActionResult DeleteIspit(int id)
        {
            Ispit ispit = db.Ispiti.Find(id);
            if (ispit == null)
            {
                return NotFound();
            }

            db.Ispiti.Remove(ispit);
            db.SaveChanges();

            return Ok(ispit);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool IspitExists(int id)
        {
            return db.Ispiti.Count(e => e.ispitID == id) > 0;
        }
    }
}