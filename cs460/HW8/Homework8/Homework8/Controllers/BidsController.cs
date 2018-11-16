using Homework8.Models;
using Homework8.Models.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace Homework8.Controllers
{
    public class BidsController : Controller

    {
        private EFAuctionContext db = new EFAuctionContext();

        // GET: API Makes a Get Request to giphy.com and returns json data
        [HttpGet]
        public JsonResult List(int? id)
        {
            string nothing = "";
            BidDashBoardVM bidList = new BidDashBoardVM();
            bidList.Item = db.Items.Find(id);
            bidList.Bids = db.Bids.Where(x => x.ItemID.Equals(1001)).OrderByDescending(i => i.Price).ToList();

            if (bidList.Item.Bids.Count > 0) {
                var list = db.Bids
                    .Select(i => new {Ident = i.ItemID,  Name = i.BuyerFullName, Amount = i.Price, CreateDate = i.TimeStamp })
                    .OrderByDescending(i => i.Amount)
                    .Where(i => i.Ident == id)
                    .ToList();
                return Json(list, JsonRequestBehavior.AllowGet);
            }

            return Json(nothing, JsonRequestBehavior.AllowGet);
        }
    }
}