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
            //ViewBag.IsPost = "GET";
            return View();
        }

        //
        // POST: /Home/Page2/
        [HttpPost]
        public ActionResult Page2(FormCollection form)
        {
            //ViewBag.IsPost = "POST";

            // And then redirect the user to another page (if desired)
            //return RedirectToAction("Index");

            if (!(IsNUll(form)))
            {
                int Lenght = int.Parse(Request.Form["Length"]);
                int Width = int.Parse(Request.Form["Width"]);
                int Height = int.Parse(Request.Form["Height"]);

                int Volume = Lenght * Width * Height;
                ViewBag.Volume = Volume.ToString();

                ViewBag.Lenght = Lenght;
                ViewBag.Width = Width;
                ViewBag.Height = Height;

                return View("Page2");
            }

            return View("Page2");
        }

        private bool IsNUll(FormCollection form){
            string L = Request.Form["Length"];
            string W = Request.Form["Width"];
            string H = Request.Form["Height"];

            if(string.IsNullOrEmpty(L) || string.IsNullOrEmpty(W) || string.IsNullOrEmpty(H))
            {
                ViewBag.IsNull = "true";
                return true;    
            }
            else
            {
                ViewBag.IsNull = "false";
                return false;
            }
        }

        //[HttpGet]
        //public ActionResult Page3(int? id, int? size, string kind)
        //{
        //    //...
        //}

    }
}
