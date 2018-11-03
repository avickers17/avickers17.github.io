using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HomeWork6.Models.ViewModels
{
    //PersonDashBoard Class needed for View when returning multiple objects
    public class PersonDashBoardVM
    {
        public Person Person { get; set; }

        public Customer Customer { get; set; }

        public IEnumerable<InvoiceLine> InvoiceLines { get; set; }

        public IEnumerable<Order> Orders { get; set; }

        public int OrderTotal { get; set; }

        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal GrossSales { get; set; }

        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal GrossProfit { get; set; }
    }
}