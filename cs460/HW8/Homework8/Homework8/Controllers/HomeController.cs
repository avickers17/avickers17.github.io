using Homework8.Models;
using Homework8.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Homework8.Controllers
{
    public class HomeController : Controller
    {
        private EFAuctionContext db = new EFAuctionContext();

        public ActionResult Index()
        {
            //create a VM item that has the top 10 most recent bids to the home index page
            BidDashBoardVM vm = new BidDashBoardVM();
            var bids = db.Bids.OrderByDescending(i => i.TimeStamp).Take(10).ToList();

            //return the list
            return View(bids);
        }

        // GET: Items/Create
        public ActionResult Create()
        {
            //code for create new item viewpage
            ViewBag.BuyerFullName = new SelectList(db.Buyers, "FullName", "FullName");
            ViewBag.ItemID = new SelectList(db.Items, "ID", "ID");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ItemID,BuyerFullName,Price,TimeStamp")] Bid bid)
        {
            //if form has been completed to create a bid, post is accepted and database is updated, redirect to homepage view
            if (ModelState.IsValid)
            {
                db.Bids.Add(bid);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            //otherwise shows a create bid page view
            ViewBag.BuyerFullName = new SelectList(db.Buyers, "FullName", "FullName", bid.BuyerFullName);
            ViewBag.ItemID = new SelectList(db.Items, "ID", "ID", bid.ItemID);
            return View(bid);
        }
    }
}