using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Homework4.Controllers
{
    public class HomeController : Controller
    {
        //Controller Action Method, Returns default "view" in this case
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Converter()
        {
            string miles = Request.QueryString["miles"];
            string units = Request.QueryString["units"];
            
            if (miles != null)
            {
                int multiplier = 0;
                string meters = "";
                if (units == "millimeters")
                {
                    multiplier = 1000000;
                    meters = "millimeters";
                }
                else if(units == "centimeters")
                {
                    multiplier = 100000;
                    meters = "centimeters";
                }
                else if (units == "meters")
                {
                    multiplier = 1000;
                    meters = "meters";
                }
                else
                {
                    multiplier = 1;
                    meters = "kilometers";
                }
                double conversion = Conversion(miles, multiplier);
                string message = "";
                double check = Convert.ToDouble(miles);
                if (check == 1 || check == 0)
                {
                    message = miles + " mile is equal to " + Convert.ToString(conversion) + " " + meters;
                }
                else
                {
                    message = miles + " miles is equal to " + Convert.ToString(conversion) + " " + meters;
                }
                ViewBag.message = message;
            }
            return View();
        }

        [HttpPost]
        public ActionResult Converter2(double miles)
        {
            Debug.WriteLine(miles);
            ViewBag.Message = "Convert Miles to Metric";
            return View();
        }

        public double Conversion(string miles, int muliplier)
        {
            double milesUpdate = Convert.ToDouble(miles);
            double kilometers = milesUpdate * 1.609344 * muliplier;
            return kilometers;

        }

    }
}