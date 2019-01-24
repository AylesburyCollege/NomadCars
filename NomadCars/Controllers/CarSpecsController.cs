






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
    public class CarSpecsController : Controller
    {
        private NomadDbContext db = new NomadDbContext();

        // GET: CarSpecs
        public ActionResult Index()
        {
            return View(db.CarSpecs.ToList());
        }

        // GET: CarSpecs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarSpec carSpec = db.CarSpecs.Find(id);
            if (carSpec == null)
            {
                return HttpNotFound();
            }
            return View(carSpec);
        }

        // GET: CarSpecs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CarSpecs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CarSpecID,Make,Model,EngineSize,Doors,Length,Width,BHP,BootCapacity,Petrol,MPG,Diesel,Electric,Seats,TaxGroup,TopSpeed,DriveTrain,BodyType,Range")] CarSpec carSpec)
        {
            if (ModelState.IsValid)
            {
                db.CarSpecs.Add(carSpec);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(carSpec);
        }

        // GET: CarSpecs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarSpec carSpec = db.CarSpecs.Find(id);
            if (carSpec == null)
            {
                return HttpNotFound();
            }
            return View(carSpec);
        }

        // POST: CarSpecs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CarSpecID,Make,Model,EngineSize,Doors,Length,Width,BHP,BootCapacity,Petrol,MPG,Diesel,Electric,Seats,TaxGroup,TopSpeed,DriveTrain,BodyType,Range")] CarSpec carSpec)
        {
            if (ModelState.IsValid)
            {
                db.Entry(carSpec).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(carSpec);
        }

        // GET: CarSpecs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarSpec carSpec = db.CarSpecs.Find(id);
            if (carSpec == null)
            {
                return HttpNotFound();
            }
            return View(carSpec);
        }

        // POST: CarSpecs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CarSpec carSpec = db.CarSpecs.Find(id);
            db.CarSpecs.Remove(carSpec);
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
