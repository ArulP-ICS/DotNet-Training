using Problem1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Problem1.Controllers
{
    public class CodeController : Controller
    {
        NorthwindEntities db = new NorthwindEntities();

        // Question 1
        public ActionResult GermanyCustomers()
        {
            var customers = db.Customers
                              .Where(c => c.Country == "Germany")
                              .ToList();

            return View(customers);
        }

        // Question 2
        public ActionResult OrderCustomer()
        {
            var customer = db.Orders
                             .Where(o => o.OrderID == 10248)
                             .Select(o => o.Customer)
                             .FirstOrDefault();

            return View(customer);
        }
    }
}