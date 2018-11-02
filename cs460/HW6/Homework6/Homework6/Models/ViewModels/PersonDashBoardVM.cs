using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Homework6.Models.ViewModels
{
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