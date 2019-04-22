using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace todo.Controllers
{
    public class AvailabilityTestController : Controller
    {
        // GET: AvailabilityTest
        public ActionResult Index()
        {
            //NOTE: here I am randomly returning a 503
            //      in a real applicaiton you should do a quick check that all your dependencies are availabile.

            var random = new Random();
            var numb = random.Next(1, 100);

            if (numb % 4 == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.ServiceUnavailable, "Service Unabailable");
            }
            else
            {
                return View();
            }
           
        }
    }
}