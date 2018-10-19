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
        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.show = false;
            return View();
        }

       [HttpPost]
        public ActionResult Create(string colorA, string colorB)
        {
            colorA = Request.Form["ColorA"];
            colorB = Request.Form["ColorB"];

            if (colorA != null && colorB != null)
            {
                ViewBag.show = true;
                Color color1 = ColorTranslator.FromHtml(colorA);
                Color color2 = ColorTranslator.FromHtml(colorB);
                Color color3 = new Color();
                
                int red = 0;
                int green = 0;
                int blue = 0;
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
                color3 = Color.FromArgb(255, red, green, blue);
                string colorC = ColorTranslator.ToHtml(color3);

                ViewBag.item1 = "width:60px; height: 60px; background:" + colorA + ";";
                ViewBag.item3 = "width:60px; height: 60px; background:" + colorB + ";";
                ViewBag.item5 = "width:60px; height: 60px; background:" + colorC + ";";
            }
           
            return View();
        }
    }
}