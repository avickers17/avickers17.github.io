using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Homework5.Models;

namespace Homework5.DAL
{   //class for creating a list of tennants using the db
    public class FormsContext : DbContext
    {
        public FormsContext() : base("name=FormData") { }

        public virtual DbSet<Tennant> Tennants  { get; set; }
    }

}