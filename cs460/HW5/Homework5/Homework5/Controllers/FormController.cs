using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Homework5.Models;

namespace Homework5.Controllers
{
    public class FormController : Controller
    {
        [HttpGet]
        public ActionResult CreateForm()
        {
            return View();
        }

        //[HttpPost]
        //public ActionResult CreateForm([Bind(Include = "FirstName, LastName, PhoneNumber, ApartmentName, UnitNumber, TextBox"
        //{

        //}
    }
}