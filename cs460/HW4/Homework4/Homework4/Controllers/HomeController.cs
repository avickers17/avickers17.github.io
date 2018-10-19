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
        //Controller Action Method, Returns default "view" for the homepage in this case
        public ActionResult Index()
        {
            return View();
        }

        //Get method for returning converter page view
        [HttpGet]
        public ActionResult Converter()
        {
            //capture form data into strings from the page once submitted
            string miles = Request.QueryString["miles"];
            string units = Request.QueryString["units"];
            
            //if miles was actually filled in with a number, perform the following
            if (miles != null)
            {
                //initializers for math and response string
                int multiplier = 0;
                string meters = "";

                //setting parameters based on user inputs
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
                
                //calls function to do the math for the conversion and sets the result to a double
                double conversion = Conversion(miles, multiplier);
                string message = "";
                //simply checks if the miles input was more than one
                double check = Convert.ToDouble(miles);

                //create string response with the updated variables
                if (check == 1 || check == 0)
                {
                    message = miles + " mile is equal to " + Convert.ToString(conversion) + " " + meters;
                }
                else
                {
                    message = miles + " miles is equal to " + Convert.ToString(conversion) + " " + meters;
                }
                //create a viewbag message to send to the user
                ViewBag.message = message;
            }
            //return the view with or without the message based on if the user entered a number for miles
            return View();
        }

        //method to run the math that takes in the miles amount and the mulitplier as set by the radio button, returns a double
        public double Conversion(string miles, int muliplier)
        {
            double milesUpdate = Convert.ToDouble(miles);
            double kilometers = milesUpdate * 1.609344 * muliplier;
            return kilometers;
        }

    }
}