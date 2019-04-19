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
        // GET: Error
        public ActionResult Index(int duration)
        {
            var random = new Random();
            Stopwatch watch = new Stopwatch();
            watch.Start();
            while (watch.ElapsedMilliseconds < duration)
            {
                var x = random.NextDouble();
                var y = random.NextDouble();
                var z = x * y;
            }

            return View();
        }
        
    }
}