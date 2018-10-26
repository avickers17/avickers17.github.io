using Homework5.DAL;
using Homework5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Homework5.Controllers
{
    public class HomeController : Controller

    {
        private FormsContext db = new FormsContext();

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,FirstName,LastName,PhoneNumber,ApartmentName,UnitNumber,TextBox,CheckBox,VerifiedDate")] Tennant tennant)
        {
            if (ModelState.IsValid)
            {
                db.Tennants.Add(tennant);
                db.SaveChanges();
                return RedirectToAction("FormsList");
            }

            return View(tennant);
        }

        public ActionResult FormsList()
        {
            return View(db.Tennants.OrderBy(Tennant => Tennant.VerifiedDate).ToList());
        }

    }
}