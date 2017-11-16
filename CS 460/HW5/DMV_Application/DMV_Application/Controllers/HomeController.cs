using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DMV_Application.DAL;
using DMV_Application.Models;

namespace DMV_Application.Controllers
{
    public class HomeController : Controller
    {
        private DMVContext db = new DMVContext();

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
            return View(db.DMVRequests.ToList());
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
