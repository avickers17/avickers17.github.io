using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Homework7.Models
{
    public class Search
    {

        public int ID { get; set; }

        public string SearchPhrase { get; set; }

        public string IpAddress { get; set; }

        public string Browser { get; set; }

        private DateTime Date = DateTime.Now;

        //VerifiedDate set by date class to set when the request was created
        public DateTime DateCreated
        {
            get { return Date; }
            set { Date = value; }
        }
    }
}