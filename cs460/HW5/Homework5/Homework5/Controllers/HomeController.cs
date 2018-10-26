using Homework5.DAL;
using Homework5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Homework5.Controllers
{
    public class HomeController : Controller

    {   //includes the list class for the database
        private FormsContext db = new FormsContext();

        //get view for homepage
        public ActionResult Index()
        {
            return View();
        }

        //get request for form creation page
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        //post request for form
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,FirstName,LastName,PhoneNumber,ApartmentName,UnitNumber,TextBox,CheckBox,VerifiedDate")] Tennant tennant)
        {
            //if form has been completed correctly and submitted
            if (ModelState.IsValid)
            {
                //access db and insert/stage new tennant data
                db.Tennants.Add(tennant);
                //save the db
                db.SaveChanges();
                //get request to take the user to the formlist view
                return RedirectToAction("FormsList");
            }
            //if form was not filled out correctly, return to the create page keeping current data
            return View(tennant);
        }

        //get view of formlist
        public ActionResult FormsList()
        {
            //shows a view of the current db informaton in a list format, and ordered from oldest to newest
            return View(db.Tennants.OrderBy(Tennant => Tennant.VerifiedDate).ToList());
        }

        //delete request/view to remove a form 
        public ActionResult Delete(int? id)
        {
            //check to make sure that we didn't get to the delete page without having an entry to delete
            if (id == null)
            {
                //return http status code
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //else find the requested delete in the database and display it for confirmation
            Tennant tennant = db.Tennants.Find(id);
            if (tennant == null)
            {
                return HttpNotFound();
            }
            return View(tennant);
        }

        //post request once delete button pressed
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //find the entry in the db
            Tennant tennant = db.Tennants.Find(id);
            //Stage the delete the entry from the db
            db.Tennants.Remove(tennant);
            //save the change in the db
            db.SaveChanges();
            //redirect back to the formlist get request
            return RedirectToAction("FormsList");
        }

        //garabage collection
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