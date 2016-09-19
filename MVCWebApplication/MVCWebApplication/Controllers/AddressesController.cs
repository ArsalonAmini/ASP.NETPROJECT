using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVCWebApplication.Models;
using GoogleMaps.LocationServices;
using Microsoft.AspNet.Identity;

namespace MVCWebApplication.Controllers
{
    public class AddressesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        
        
        // GET: Addresses
        public ActionResult Index()
        {
            var address = db.Address;
            return View(address.ToList());
        }

        
        

        // GET: Addresses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Address address = db.Address.Find(id);
            if (address == null)
            {
                return HttpNotFound();
            }
            return View(address);
        }

        
        

        // POST: Addresses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Street,City,State,Latitude, Longitude")] Address address)
        {
            
            if (ModelState.IsValid)
            {
                var location = address.Street + address.City;
                var locationService = new GoogleLocationService();
                var point = locationService.GetLatLongFromAddress(location);
                var latitude = point.Latitude;
                var longitude = point.Longitude;
                address.Latitude = latitude;
                address.Longitude = longitude;

                db.Address.Add(address);
                db.SaveChanges();
                //return RedirectToAction("Index");
                return RedirectToAction("Create", "Services");
            }

            ViewBag.UserId = new SelectList(db.Users, "Id", "FirstName", address.id);
            return View(address);
        }

        // GET: Addresses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Address address = db.Address.Find(id);
            if (address == null)
            {
                return HttpNotFound();
            }
            //ViewBag.CityID = new SelectList(db.City, "ID", "Name", address.CityID);
            //ViewBag.CountryID = new SelectList(db.Country, "ID", "name", address.CountryID);
            //ViewBag.StateID = new SelectList(db.State, "ID", "Name", address.StateID);
            return View(address);
        }

        // POST: Addresses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Street,CityID,StateID,CountryID")] Address address)
        {
            if (ModelState.IsValid)
            {
                db.Entry(address).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            //ViewBag.CityID = new SelectList(db.City, "ID", "Name", address.CityID);
            //ViewBag.CountryID = new SelectList(db.Country, "ID", "name", address.CountryID);
            //ViewBag.StateID = new SelectList(db.State, "ID", "Name", address.StateID);
            return View(address);
        }

        // GET: Addresses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Address address = db.Address.Find(id);
            if (address == null)
            {
                return HttpNotFound();
            }
            return View(address);
        }

        // POST: Addresses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Address address = db.Address.Find(id);
            db.Address.Remove(address);
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
