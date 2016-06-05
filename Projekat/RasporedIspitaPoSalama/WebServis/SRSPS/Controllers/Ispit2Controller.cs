﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebServis.Models;
using WebServis.SRSPS.Models;

namespace WebServis.SRSPS.Controllers
{
    public class Ispit2Controller : Controller
    {
        private SRSPSDB db = new SRSPSDB();

        // GET: Ispit2
        public ActionResult Index()
        {
            return View(db.Ispits.ToList());
        }

        // GET: Ispit2/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ispit ispit = db.Ispits.Find(id);
            if (ispit == null)
            {
                return HttpNotFound();
            }
            return View(ispit);
        }

        // GET: Ispit2/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Ispit2/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ispitID,brojPrijavljenih")] Ispit ispit)
        {
            if (ModelState.IsValid)
            {
                db.Ispits.Add(ispit);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ispit);
        }

        // GET: Ispit2/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ispit ispit = db.Ispits.Find(id);
            if (ispit == null)
            {
                return HttpNotFound();
            }
            return View(ispit);
        }

        // POST: Ispit2/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ispitID,brojPrijavljenih")] Ispit ispit)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ispit).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ispit);
        }

        // GET: Ispit2/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ispit ispit = db.Ispits.Find(id);
            if (ispit == null)
            {
                return HttpNotFound();
            }
            return View(ispit);
        }

        // POST: Ispit2/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ispit ispit = db.Ispits.Find(id);
            db.Ispits.Remove(ispit);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}