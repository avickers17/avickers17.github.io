using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Homework6.Models;


namespace Homework6.Controllers
{
    public class HomeController : Controller
    {
        //includes the list class for the database
        private EFImportersContext db = new EFImportersContext();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Employee(int? id)
        {
            if (id == null)
            {
                //return http status code
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //else find the requested delete in the database and display it for confirmation
            Person person = db.People.Find(id);
            if (person == null)
            {
                return HttpNotFound();
            }
            return View(person);
        }

        [HttpGet]
        public ActionResult Search()
        {
            string name = Request.QueryString["FullName"];
            string heading = "Names matching your Search:";
            if (name != null)
            {
                ViewBag.message = heading;
            }
            return View(db.People.Where(n => n.FullName.Contains(name)).ToList());
        }
    }

}