using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Homework8.Models.ViewModels
{
    public class BidDashBoardVM
    {
        //VM model class for returning specific item along with it's specific bids
        public Item Item { get; set; }

        public IEnumerable<Bid> Bids { get; set; }
    }
}