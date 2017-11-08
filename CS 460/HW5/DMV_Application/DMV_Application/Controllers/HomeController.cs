using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DMV_Application.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View ();
        }

        public ActionResult Requests()
        {
            return View();
        }

        public ActionResult ChangeAdd()
        {
            return View();
        }
    }
}
