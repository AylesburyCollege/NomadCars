using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using NomadCars.DAL;
using NomadCars.Models;

namespace NomadCars.Controllers
{
    /// <summary>
    /// Author: Zeeshan
    /// This controller will allow members of staff to
    /// add, edit, delete, and view cars
    /// </summary>
    //[Authorize(Roles = "Staff")]
    public class CarsController : Controller
    {
        private NomadDbContext db = new NomadDbContext();
        //private Car car;

        // GET: Cars
        [Authorize(Roles = "Staff")]
        public ActionResult Index()
        {
            var cars = db.Cars.Include(c => c.CarSpec);
            return View(cars.ToList());
        }

        // GET: Cars/Details/5
        [Authorize (Roles = "Staff")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Car car = db.Cars.Find(id);
            if (car == null)
            {
                return HttpNotFound();
            }
            return View(car);
        }

        public ActionResult CarDetails(int id)
        {
            Car car = db.Cars.Find(id);

            if (car == null)
            {
                return HttpNotFound();
            }
            return View(car);
          
        }

        // GET: Cars/Create
        public ActionResult Create()
        {
            ViewBag.CarSpecID = new SelectList(db.CarSpecs, "CarSpecID", "CarSpecID");
            return View();
        }

        // POST: Cars/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CarID,Colour,NumberPlate,VINNo,Mileage,TransmissionType,NoPreviousOwner,AccelerationTo60,Sold,Delivered,CO2Emissions,CarSpecID")] Car car)
        {
            if (ModelState.IsValid)
            {
                db.Cars.Add(car);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CarSpecID = new SelectList(db.CarSpecs, "CarSpecID", "CarSpecID", car.CarSpecID);
            return View(car);
        }

        // GET: Cars/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Car car = db.Cars.Find(id);
            if (car == null)
            {
                return HttpNotFound();
            }
            ViewBag.CarSpecID = new SelectList(db.CarSpecs, "CarSpecID", "CarSpecID", car.CarSpecID);
            return View(car);
        }

        // POST: Cars/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CarID,Colour,NumberPlate,VINNo,Mileage,TransmissionType,NoPreviousOwner,AccelerationTo60,Sold,Delivered,CO2Emissions,CarSpecID")] Car car)
        {
            if (ModelState.IsValid)
            {
                db.Entry(car).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CarSpecID = new SelectList(db.CarSpecs, "CarSpecID", "CarSpecID", car.CarSpecID);
            return View(car);
        }

        // GET: Cars/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Car car = db.Cars.Find(id);
            if (car == null)
            {
                return HttpNotFound();
            }
            return View(car);
        }

        // POST: Cars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Car car = db.Cars.Find(id);
            db.Cars.Remove(car);
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
