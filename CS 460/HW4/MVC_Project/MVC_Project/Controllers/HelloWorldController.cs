using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Project.Controllers
{
    public class HelloWorldController : Controller
    {
        //
        // GET: /HelloWorld/
        public ActionResult Index()
        {
            ViewBag.Countries = new List<string>()
            {
                "USA",
                "Mexico",
                "Canada"
            };

            ViewData["Cities"] = new List<string>()
            {
                "Salem",
                "Woodburn",
                "Monmouth"
            };

            return View();
        }

        //
        // GET: /HelloWorld/IndexGet/
        [HttpGet]
        public ActionResult IndexGet()
        {
            ViewBag.IsPostback = IsPost();
            return View();
        }

        [HttpPost]
        [ActionName("IndexGet")]
        public ActionResult IndexPost()
        {
            ViewBag.IsPostback = IsPost();
            return View();
        }


        private bool IsPost()
        {
            return Request.HttpMethod == "POST";
        }
    }
}
