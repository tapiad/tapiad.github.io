using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Configuration;
using DMV_Application.DAL;
using DMV_Application.Models;

namespace DMV_Application.Controllers
{
    public class HomeController : Controller
    {
        private DMVContext Db = new DMVContext();

        //
        // GET: /Home
        public ActionResult Index()
        {

            return View();
        }

        //
        // GET: /Home/Requests
        public ActionResult Requests()
        {
            return View(Db.DMVRequest.ToList());
        }
        //
        // GET: /Home/ChangeAdd
        public ActionResult ChangeAdd()
        {
            return View();
        }

        //
        // GET: /Home/ChangeAdd
        [HttpPost]
        public ActionResult ChangeAdd(FormCollection form)
        {
            foreach(string elem in form)
            {
                Console.WriteLine();
            }
            TempData["CID"] = Request.Form["CID"];
            TempData["CID"] = Request.Form["CID"];
            TempData["CID"] = Request.Form["CID"];
            TempData["CID"] = Request.Form["CID"];
            TempData["CID"] = Request.Form["CID"];
            TempData["CID"] = Request.Form["CID"];
            TempData["CID"] = Request.Form["CID"];
            TempData["CID"] = Request.Form["CID"];
            TempData["CID"] = Request.Form["CID"];
            return RedirectToAction("PRG");
        }

        //
        // get: /Home/PRG
        /// <summary>
        ///  Thank you Page (GET-POST-Redirect)
        /// </summary>
        /// <returns>PRG View</returns>
        public ActionResult PRG()
        {
            ViewBag.CID = TempData["CID"];
            return View();
        }
    }
}
