using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Homework8.Models;
using Homework8.Models.ViewModels;

namespace Homework8.Controllers
{
    public class ItemsController : Controller
    {
        private EFAuctionContext db = new EFAuctionContext();

        // GET: Items
        public ActionResult Index()
        {
            var items = db.Items.Include(i => i.Seller);
            return View(items.ToList());
        }

        // GET: Items/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BidDashBoardVM item = new BidDashBoardVM() { Item = db.Items.Find(id) };
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        // GET: Home/Create
        public ActionResult Create()
        {
            ViewBag.SellerFullName = new SelectList(db.Sellers, "FullName", "FullName");
            return View();
        }

        // POST: Items/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Description,SellerFullName")] Item item)
        {
            //if form state is filled in correctly, update the db and redirect to the list page
            if (ModelState.IsValid)
            {
                db.Items.Add(item);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            //otherwise show item create page
            ViewBag.SellerFullName = new SelectList(db.Sellers, "FullName", "FullName", item.SellerFullName);
            return View(item);
        }

        // GET: Items/Edit/
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item item = db.Items.Find(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            ViewBag.SellerFullName = new SelectList(db.Sellers, "FullName", "FullName", item.SellerFullName);
            return View(item);
        }

        // POST: Items/Edit/
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Description,SellerFullName")] Item item)
        {
            if (ModelState.IsValid)
            {
                db.Entry(item).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SellerFullName = new SelectList(db.Sellers, "FullName", "FullName", item.SellerFullName);
            return View(item);
        }

        // GET: Items/Delete/
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item item = db.Items.Find(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        // POST: Items/Delete/
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Item item = db.Items.Find(id);
            db.Items.Remove(item);
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
