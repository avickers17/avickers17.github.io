using System.Linq;
using System.Net;
using System.Web.Mvc;
using Homework6.Models;
using System.Diagnostics;
using Homework6.Models.ViewModels;

namespace Homework6.Controllers
{
    public class HomeController : Controller
    {
        //includes the list class for the database
        private EFImportersContext db = new EFImportersContext();

        //View for Homepage
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Employee(int? id)
        {
            ViewBag.Check = false;
            if (id == null)
            {
                //return http status code
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            PersonDashBoardVM vm = new PersonDashBoardVM();
            vm.Person = db.People.Find(id);
            if (vm.Person == null)
            {
                return HttpNotFound();
            }
            //else find the requested delete in the database and display it for confirmation
            //int otherID = db.People.Find(id).Customers2.FirstOrDefault().PrimaryContactPersonID;
            
            if (vm.Person.Customers2.Count() > 0 )
            {
                ViewBag.Check = true;
                int custId = db.People.Find(id).Customers2.FirstOrDefault().CustomerID;
                vm.Customer = vm.Person.Customers2.FirstOrDefault();
                vm.Orders = vm.Customer.Orders.ToList();
                vm.OrderTotal = vm.Customer.Orders.Count;
                var total = vm.Orders.SelectMany(i => i.Invoices).SelectMany(inv => inv.InvoiceLines).Select(price => new { price.ExtendedPrice }).ToList();
                vm.GrossSales = total.Select(i => i.ExtendedPrice).Sum();
                var secondTotal = vm.Orders.SelectMany(i => i.Invoices).SelectMany(inv => inv.InvoiceLines).Select(price => new { price.LineProfit
                }).ToList();
                vm.GrossProfit = secondTotal.Select(i => i.LineProfit).Sum();
                vm.InvoiceLines = vm.Orders.SelectMany(i => i.Invoices).SelectMany(inv => inv.InvoiceLines)
                    .OrderByDescending(i => i.LineProfit).Take(10);
            }
            return View(vm);
        }

        
   
        [HttpGet]
        public ActionResult Search()
        {
            ViewBag.show = false;
            string name = Request.QueryString["FullName"];
            string heading = "Names matching your Search:";
            string headingTwo = "I'm sorry, your search returned no results";
            ViewBag.message = "";
            var list = db.People.Where(n => n.FullName.Contains(name)).ToList();
            if (name != null && !list.Any())
            {
                ViewBag.message = headingTwo;
                ViewBag.show = true;
                return View(list);
            }
            else if(name != null && list.Any())
            {
                ViewBag.message = heading;
                ViewBag.show = true;
                return View(list);
            }
            else
            {
                return View(list);
            }
            
        }
    }

}