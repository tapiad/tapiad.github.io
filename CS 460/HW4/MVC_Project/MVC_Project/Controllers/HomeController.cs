using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;

namespace MVC_Project.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        public ActionResult Index()
        {
            var mvcName = typeof(Controller).Assembly.GetName();
            var isMono = Type.GetType("Mono.Runtime") != null;

            ViewData["Version"] = mvcName.Version.Major + "." + mvcName.Version.Minor;
            ViewData["Runtime"] = isMono ? "Mono" : ".NET";


            Debug.WriteLine("This is Home");

            return View();
        }

        //
        // GET: /Home/Page1/
        public ActionResult Page1()
        {
            Debug.WriteLine("This is Page1()");
            return View();
        }

        //
        // GET: /Home/TheBank/
        public ActionResult TheBank()
        {
            string USD = Request.QueryString["USD"];
            string MP = Request.QueryString["MP"];

            if(!string.IsNullOrEmpty(USD))
            {
                int US = int.Parse(USD);
                ViewBag.MP = Math.Round((US * 19.264299), 2).ToString();//As of November 2017
                return View();
            }
            if(!string.IsNullOrEmpty(MP))
            {
                int MX = int.Parse(MP);
                ViewBag.USD = Math.Round((MX * 0.051946), 2).ToString();//As of November 2017
                return View();
            }
            return View();
        }

        //
        // Get: /Home/Page2/
        [HttpGet]
        public ActionResult Page2()
        {
            return View();
        }

        //
        // POST: /Home/Page2/
        [HttpPost]
        public ActionResult Page2(FormCollection form)
        {
            // Values POSTed can be retrieved from the FormCollection object
            Console.WriteLine("This is POST of Page 2.");
            return View();
        }

    }
}
