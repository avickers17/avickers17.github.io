using HomeWork6.Models;
using HomeWork6.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace HomeWork6.Controllers
{
    public class HomeController : Controller
    {
        //includes the list class for the database
        private EFImportersContext db = new EFImportersContext();

        public ActionResult Index()
        {
            return View();
        }

        //Action for Employee/Customer Results View, requires search id parameter
        public ActionResult Employee(int? id)
        {
            ViewBag.Check = false;
            if (id == null)
            {
                //return http status code
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Initialize a PersonDashBoard Class
            PersonDashBoardVM vm = new PersonDashBoardVM();
            //set vm.Person to database information for that person based on their personal id
            vm.Person = db.People.Find(id);

            if (vm.Person == null)
            {
                return HttpNotFound();
            }

            //If the person has customer data, they are a customer
            if (vm.Person.Customers2.Count() > 0)
            {
                //View information will display in view
                ViewBag.Check = true;

                //Set an int linking the person id and the customer information id
                int custId = db.People.Find(id).Customers2.FirstOrDefault().CustomerID;

                //Set vm.Customer information to the first customer object in person's customer database info
                vm.Customer = vm.Person.Customers2.FirstOrDefault();

                //Set vm.Orders to that customers list of orders placed 
                vm.Orders = vm.Customer.Orders.ToList();

                //Set vm.OrderTotal to the total amount of orders placed by customer
                vm.OrderTotal = vm.Customer.Orders.Count;

                //Get a list of orders to sum the total amount spent in orders
                var total = vm.Orders.SelectMany(i => i.Invoices).SelectMany(inv => inv.InvoiceLines).Select(price => new { price.ExtendedPrice }).ToList();

                //Set vm.GrossSales to the total of that list based on ExtendedPrice column
                vm.GrossSales = total.Select(i => i.ExtendedPrice).Sum();

                //Get a second list of order information for LineProfit data
                var secondTotal = vm.Orders.SelectMany(i => i.Invoices).SelectMany(inv => inv.InvoiceLines).Select(price => new
                { price.LineProfit}).ToList();

                //Set vm.GrossProfit to the sum of second list
                vm.GrossProfit = secondTotal.Select(i => i.LineProfit).Sum();

                //Set vm.InvoiceLines list to the list of the top ten most expensive items purchased by customer
                vm.InvoiceLines = vm.Orders.SelectMany(i => i.Invoices).SelectMany(inv => inv.InvoiceLines)
                    .OrderByDescending(i => i.LineProfit).Take(10);
            }
            //Return vm object for viewing
            return View(vm);
        }

        //Get Request for Search View Page
        [HttpGet]
        public ActionResult Search()
        {
            //start with message not showing
            ViewBag.show = false;
            //get the name from the query string
            string name = Request.QueryString["FullName"];
            string heading = "Names matching your Search:";
            string headingTwo = "I'm sorry, your search returned no results";
            ViewBag.message = "";
            //search the db for a list of people whos name contain the user's search entry
            var list = db.People.Where(n => n.FullName.Contains(name)).ToList();
            //if the query is not empty and the list is not empty
            if (name != null && !list.Any())
            {
                //Message shows, return the list to the search view
                ViewBag.message = headingTwo;
                ViewBag.show = true;
                return View(list);
            }
            //if the query name was not empty but the list didnt return any results
            else if (name != null && list.Any())
            {
                //show a no results message, return the basic view and empty list
                ViewBag.message = heading;
                ViewBag.show = true;
                return View(list);
            }
            //else simply show the viewpage for search
            else
            {
                return View(list);
            }
        }
    }
}