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
            //NOTE: here I am always returning a 503
            //      however in a real applicaiton you should to some quick tests to see if things are good
            //      for example, if you require a connection to cosmosdb and redis, check them here.
            return new HttpStatusCodeResult(HttpStatusCode.ServiceUnavailable, "Service Unabailable");
        }
    }
}