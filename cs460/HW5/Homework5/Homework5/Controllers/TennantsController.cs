using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Homework5.DAL;
using Homework5.Models;

namespace Homework5.Controllers
{
    public class TennantsController : Controller
    {
        private FormsContext db = new FormsContext();

        // GET: Tennants
        public ActionResult Index()
        {
            return View(db.Tennants.ToList());
        }

        // GET: Tennants/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tennant tennant = db.Tennants.Find(id);
            if (tennant == null)
            {
                return HttpNotFound();
            }
            return View(tennant);
        }

        // GET: Tennants/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tennants/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,FirstName,LastName,PhoneNumber,ApartmentName,UnitNumber,TextBox,CheckBox,VerifiedDate")] Tennant tennant)
        {
            if (ModelState.IsValid)
            {
                db.Tennants.Add(tennant);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tennant);
        }

        // GET: Tennants/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tennant tennant = db.Tennants.Find(id);
            if (tennant == null)
            {
                return HttpNotFound();
            }
            return View(tennant);
        }

        // POST: Tennants/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,FirstName,LastName,PhoneNumber,ApartmentName,UnitNumber,TextBox,CheckBox,VerifiedDate")] Tennant tennant)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tennant).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tennant);
        }

        // GET: Tennants/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tennant tennant = db.Tennants.Find(id);
            if (tennant == null)
            {
                return HttpNotFound();
            }
            return View(tennant);
        }

        // POST: Tennants/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tennant tennant = db.Tennants.Find(id);
            db.Tennants.Remove(tennant);
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
