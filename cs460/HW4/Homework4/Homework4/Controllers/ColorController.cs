using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Drawing;
using System.Diagnostics;

namespace Homework4.Controllers
{
    public class ColorController : Controller
    {
        //basic landing page and view on initial get request, don't show color info on inital landing
        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.show = false;
            return View();
        }
        //once the user posts data this function is called to respond and return a new view
       [HttpPost]
        public ActionResult Create(string colorA, string colorB)
        {
            //capture the strings from the form inputs
            colorA = Request.Form["ColorA"];
            colorB = Request.Form["ColorB"];
            
            //double check to make sure that the fields are filled out
            if (colorA != null && colorB != null)
            {
                //now show additional color boxes
                ViewBag.show = true;
                
                //create 3 Color objects that transform string hex data into numbers that can be adjusted
                Color color1 = ColorTranslator.FromHtml(colorA);
                Color color2 = ColorTranslator.FromHtml(colorB);
                Color color3 = new Color();
                
                //initalizers for Color 3
                int red = 0;
                int green = 0;
                int blue = 0;

                //if check to combine each color value but not exceed 255
                if (color1.R + color2.R > 255)
                {
                    red = 255;
                }
                else
                {
                    red = color1.R + color2.R;
                }
                if (color1.G + color2.G > 255)
                {
                    green = 255;   
                }
                else
                {
                    green = color1.G + color2.G;
                }
                if (color1.B + color2.B > 255)
                {
                    blue = 255;
                }
                else
                {
                    blue = color1.B + color2.B;
                }

                //Adjust color 3 to match the mix
                color3 = Color.FromArgb(255, red, green, blue);

                //Convert color3 back into a string used for posting
                string colorC = ColorTranslator.ToHtml(color3);

                //now that colors are set, create 3 boxes that have a background of the chosen color combos
                ViewBag.item1 = "width:60px; height: 60px; background:" + colorA + ";";
                ViewBag.item3 = "width:60px; height: 60px; background:" + colorB + ";";
                ViewBag.item5 = "width:60px; height: 60px; background:" + colorC + ";";
            }
            else
            {
                //keeping these at null in case either form section was not filled in correctly and a POST request made
                ViewBag.item1 = null;
                ViewBag.item3 = null;
                ViewBag.item5 = null;
            }
            //Return the view with the updated boxes
            return View();
        }
    }
}