using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebEF.Models;

namespace WebEF.Controllers
{
    public class HomeController : Controller
    {
        PeopleDbContext db = new PeopleDbContext();

        // GET: Home
        public ActionResult Index(string orderBy)
        {
            List<Person> myList = new List<Person>();
            if (string.IsNullOrEmpty(orderBy))
            {
                ViewBag.OrderNameBy = "NameA";
                myList = db.People.ToList();
            }
            else
            {
                switch (orderBy)
                {
                    case "NameA":
                        myList = db.People.OrderBy(p => p.Name).ToList();
                        ViewBag.OrderNameBy = "NameD";
                        break;
                    case "NameD":
                        myList = db.People.OrderByDescending(p => p.Name).ToList();
                        ViewBag.OrderNameBy = "NameA";
                        break;
                }
            }
            
            return View(myList);
        }

        public ActionResult Create()
        {
            Person me = new Person();
            me.Name = "Bobbo";
            me.Age = 99;
            me.City = "LA";

            db.People.Add(me); //Adds Bobbo to DB
            db.SaveChanges();  // saves the changes (add Bobbo)

            return RedirectToAction("Index");
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Person person = db.People.Include("Cars").SingleOrDefault(p => p.Id == id);
            if (person == null)
            {
                return HttpNotFound();
            }
            return View(person);
        }

        [HttpGet]
        public ActionResult AddCarToPerson(int pId)
        {
            List<Car> cars = db.Cars.ToList();

            ViewBag.pId = pId;//Person Id

            return View(cars);
        }
        [HttpGet]
        public ActionResult CarToPerson(int cId, int pId)
        {
            Car car = db.Cars.SingleOrDefault(c => c.Id == cId);

            Person person = db.People.Include("Cars").SingleOrDefault(p => p.Id == pId);

            person.Cars.Add(car);

            db.SaveChanges();

            return RedirectToAction("Details", new { id = pId });
        }
    }
}