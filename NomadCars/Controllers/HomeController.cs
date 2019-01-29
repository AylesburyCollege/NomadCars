using NomadCars.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NomadCars.Controllers
{
    public class HomeController : Controller
    {
        private NomadDbContext db = new NomadDbContext();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Finance()
        {
            ViewBag.Message = "Your finance page.";

            return View();
        }


        public ActionResult UsedCars()
        {
            var cars = db.Cars;
            return View(cars.ToList());
        }
    }
}