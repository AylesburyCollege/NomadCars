using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using NomadCars.DAL;
using NomadCars.Models;
using PagedList;

namespace NomadCars.Controllers
{
    /// <summary>
    /// Author: William
    /// 
    /// This controller will allow people, both staff
    /// and customers to edit their specific details. 
    /// However, only staff can view or delete 
    /// people's details.
    /// Customers should also only be able to edit their
    /// own details.
    /// </summary>
    
    [Authorize]
    public class PeopleController : Controller
    {
        private NomadDbContext db = new NomadDbContext();
        private Person customer;

        // GET: People        
        [Authorize(Roles = "Staff")]
        public ViewResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.DateSortParam = sortOrder == "DOB" ? "DOB_desc" : "DOB";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            ViewBag.CurrentFilter = searchString;

            var people = from s in db.People
                         select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                people = people.Where(s => s.LastName.Contains(searchString)
                                    || s.FirstName.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    people = people.OrderByDescending(s => s.LastName);
                    break;
                case "DOB":
                    people = people.OrderBy(s => s.DateOfBirth);
                    break;
                case "DOB_desc":
                    people = people.OrderByDescending(s => s.DateOfBirth);
                    break;
                default:
                    people = people.OrderBy(s => s.LastName);
                    break;
            }

            int pageSize = 4;
            int pageNumber = (page ?? 1);
            return View(people.ToPagedList(pageNumber, pageSize));
        }

        // GET: People/Details/5
        [Authorize(Roles = "Staff")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Person person = db.People.Find(id);
            if (person == null)
            {
                return HttpNotFound();
            }
            return View(person);
        }

        // GET: People/Details/5
        [Authorize(Roles = "Staff")]
        public ActionResult CustomerDetails()
        {

            string email = User.Identity.Name;
            customer = db.People.Where(p => p.Email == email).Include(s => s.Staff).FirstOrDefault();


            if (customer == null)
            {

                return RedirectToAction("Create");
            }


            return View(customer);
        }
        // GET: People/Create
        public ActionResult Create()
        {
            //ViewBag.PersonID = new SelectList(db.Addresses, "AddressID", "House");
            //ViewBag.PersonID = new SelectList(db.Staff, "StaffID", "Department");

            string email = User.Identity.Name;

            customer = new Person();
            customer.DateOfBirth = new System.DateTime(1990, 1, 1);
            customer.Email = email;
            customer.IsStaff = false;
            customer.IsCustomer = true;

            return View(customer);
        }

        // POST: People/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PersonID,FirstName,LastName,HomePhoneNumber,MobilePhoneNumber,Email,DateOfBirth,MaritalStatus,IsCustomer,IsStaff")] Person person)
        {
            if (ModelState.IsValid)
            {
                db.People.Add(person);
                db.SaveChanges();

                return RedirectToAction("CustomerDetails");
            }

            ViewBag.PersonID = new SelectList(db.Addresses, "AddressID", "House", person.PersonID);
            ViewBag.PersonID = new SelectList(db.Staff, "StaffID", "Department", person.PersonID);
            return View(person);
        }

        // GET: People/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Person person = db.People.Find(id);
            if (person == null)
            {
                return HttpNotFound();
            }

            ViewBag.PersonID = new SelectList(db.Addresses, "AddressID", "House", person.PersonID);
            ViewBag.PersonID = new SelectList(db.Staff, "StaffID", "Department", person.PersonID);

            return View(person);
        }

        // POST: People/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PersonID,FirstName,LastName,HomePhoneNumber,MobilePhoneNumber,Email,DateOfBirth,MaritalStatus,IsCustomer,IsStaff")] Person person)
        {
            if (ModelState.IsValid)
            {
                db.Entry(person).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("CustomerDetails");
            }

            ViewBag.PersonID = new SelectList(db.Addresses, "AddressID", "House", person.PersonID);
            ViewBag.PersonID = new SelectList(db.Staff, "StaffID", "Department", person.PersonID);

            return View(person);
        }

        // GET: People/Delete/5
        [Authorize(Roles = "Staff")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Person person = db.People.Find(id);
            if (person == null)
            {
                return HttpNotFound();
            }
            return View(person);
        }

        // POST: People/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Staff")]
        public ActionResult DeleteConfirmed(int id)
        {
            Person person = db.People.Find(id);
            db.People.Remove(person);
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
