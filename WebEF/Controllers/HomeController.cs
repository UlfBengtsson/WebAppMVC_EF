using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebEF.Models;

namespace WebEF.Controllers
{
    public class HomeController : Controller
    {
        PeopleDbContext db = new PeopleDbContext();

        // GET: Home
        public ActionResult Index()
        {
            List<Person> myList = db.people.ToList();
            return View(myList);
        }

        public ActionResult Create()
        {
            Person me = new Person();
            me.Name = "Bobbo";
            me.Age = 99;
            me.City = "LA";

            db.people.Add(me); //Adds Bobbo to DB
            db.SaveChanges();  // saves the changes (add Bobbo)

            return RedirectToAction("Index");
        }
    }
}