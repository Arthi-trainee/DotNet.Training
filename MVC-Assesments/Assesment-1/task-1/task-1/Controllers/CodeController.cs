using System;

using System.Collections.Generic;

using System.Linq;

using System.Web;

using System.Web.Mvc;

using AssessmentMvc.Models;

namespace AssessmentMvc.Controllers

{

    public class CodeController : Controller

    {

        private northwindEntities db = new northwindEntities();

        // GET: Code

        //public ActionResult Index()

        //{

        //    return View();

        //}

        // Action 1: Return all customers residing in Germany

        public ActionResult CustomersInGermany()

        {

            var germanCustomers_details = db.Customers.Where(c => c.Country == "Germany").ToList();

            return View(germanCustomers_details); 

        }

        // Action 2: Return customer details with orderId == 10248

        public ActionResult CustomerDetailsWithOrder()

        {

            var customerDetails_10248 = db.Orders

                .Where(o => o.OrderID == 10248)

                .Select(o => new

                {

                    o.Customer.CustomerID,

                    o.Customer.CompanyName,

                    o.Customer.ContactName,

                    o.Customer.Country,

                    o.OrderDate

                }).FirstOrDefault();

            return View(customerDetails_10248); 

        }

    }

}
