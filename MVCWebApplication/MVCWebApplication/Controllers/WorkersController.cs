﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVCWebApplication.Models;

namespace MVCWebApplication.Controllers
{
    public class WorkersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
         

        public ActionResult ViewCustomersMap()
        {
            var address = db.Address.Include(a => a.Street).Include(a => a.City).Include(a => a.State).Include(a => a.Latitude).Include(a => a.Longitude);
            List<Address> addressList = new List<Address>();
            return View(addressList);
        }
        // GET: Workers
        public ActionResult Index()
        {
            var worker = db.Worker.Include(w => w.ApplicationUser);
             return View(worker.ToList());
        }

        
        // GET: Workers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Worker worker = db.Worker.Find(id);
            if (worker == null)
            {
                return HttpNotFound();
            }
            return View(worker);
        }

        // GET: Workers/Create
        public ActionResult Create()
        {
            ViewBag.ApplicationUserID = new SelectList(db.Worker, "Id", "Email");
            return View();
        }

        // POST: Workers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ApplicationUserID")] Worker worker)
        {
            if (ModelState.IsValid)
            {
                db.Worker.Add(worker);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ApplicationUserID = new SelectList(db.Worker, "Id", "Email", worker.ApplicationUserID);
            return View(worker);
        }

        // GET: Workers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Worker worker = db.Worker.Find(id);
            if (worker == null)
            {
                return HttpNotFound();
            }
            ViewBag.ApplicationUserID = new SelectList(db.Worker, "Id", "Email", worker.ApplicationUserID);
            return View(worker);
        }

        // POST: Workers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ApplicationUserID")] Worker worker)
        {
            if (ModelState.IsValid)
            {
                db.Entry(worker).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ApplicationUserID = new SelectList(db.Worker, "Id", "Email", worker.ApplicationUserID);
            return View(worker);
        }

        // GET: Workers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Worker worker = db.Worker.Find(id);
            if (worker == null)
            {
                return HttpNotFound();
            }
            return View(worker);
        }

        // POST: Workers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Worker worker = db.Worker.Find(id);
            db.Worker.Remove(worker);
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
