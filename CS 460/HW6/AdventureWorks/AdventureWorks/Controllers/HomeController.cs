using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AdventureWorks.Models;

namespace AdventureWorks.Controllers
{
    public class HomeController : Controller
    {
        private AWContext db = new AWContext();

        // GET: Home
        public ActionResult Index()
        {
            return View(db.ProductCategories.ToList());
        }

        // GET: About
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        // GET: Contact
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

    }
}