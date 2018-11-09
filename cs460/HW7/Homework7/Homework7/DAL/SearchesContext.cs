using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Homework7.Models;

namespace Homework7.DAL
{
    public class SearchesContext : DbContext
    {
        //class for creating a list of tennants using the db
       
        public SearchesContext() : base("name=Searches") { }

        public virtual DbSet<Search> Searches { get; set; }
        
    }
}