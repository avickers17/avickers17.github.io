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

        // GET: Returns DB information for details viewpage and returns result in json format
        [HttpGet]
        public JsonResult List(int? id)
        {
            //string to return no data if there are no bids on item
            string nothing = "";
            
            //new dashboard item created
            BidDashBoardVM bidList = new BidDashBoardVM();
            
            //item is pulled from database based on item id
            bidList.Item = db.Items.Find(id);
            //its list of bids is pulled also based on its specific id
            bidList.Bids = db.Bids.Where(x => x.ItemID.Equals(1001)).OrderByDescending(i => i.Price).ToList();

            //if the bids list is greater than 0
            if (bidList.Item.Bids.Count > 0) {
                //create a new var list of bids allowing me to select and name specific columns
                var list = db.Bids
                    .Select(i => new {Ident = i.ItemID,  Name = i.BuyerFullName, Amount = i.Price, CreateDate = i.TimeStamp })
                    .OrderByDescending(i => i.Amount)
                    .Where(i => i.Ident == id)
                    .ToList();
                //return this list in json format for processing
                return Json(list, JsonRequestBehavior.AllowGet);
            }
            //return an empty string if there are no bids
            return Json(nothing, JsonRequestBehavior.AllowGet);
        }
    }
}