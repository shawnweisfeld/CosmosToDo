using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace todo.Controllers
{
    public class LoadController : Controller
    {
        // GET: Generate load on the cpu for between 1 to 5 seconds. 
        public ActionResult Index()
        {
            var random = new Random();
            Stopwatch watch = new Stopwatch();
            watch.Start();
            var duration = random.Next(1, 5);
            while (watch.Elapsed.TotalSeconds < duration)
            {
                var x = random.NextDouble();
                var y = random.NextDouble();
                var z = x * y;
            }

            return View();
        }
        
    }
}