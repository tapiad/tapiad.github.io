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
        /// <summary>
        /// Creats db
        /// </summary>
        private DMVContext db = new DMVContext();

        /// <summary>
        /// Home page of DMV
        /// </summary>
        /// <returns>Index View()</returns>
        // GET: /Home
        public ActionResult Index()
        {

            return View();
        }

        /// <summary>
        /// View Pending Requests
        /// </summary>
        /// <returns>Requests View()</returns>
        // GET: /Home/Requests
        public ActionResult Requests()
        {
            return View(db.DMVRequests.ToList());
        }

        /// <summary>
        /// A Change Request Form
        /// </summary>
        /// <returns>ChangeAdd View()</returns>
        // GET: /Home/ChangeAdd
        public ActionResult ChangeAdd()
        {
            return View();
        }

        /// <summary>
        /// Adding input values into a TempData
        /// </summary>
        /// <param name="form">User Input Values</param>
        /// <returns>Redirect To Action (PRG)</returns>
        // GET: /Home/ChangeAdd
        [HttpPost]
        public ActionResult ChangeAdd(FormCollection form)
        {
            TempData["CID"] = Request.Form["CID"];
            TempData["DOB"] = Request.Form["DOB"];
            TempData["Name"] = Request.Form["Name"];
            TempData["Address"] = Request.Form["Address"];
            TempData["City"] = Request.Form["City"];
            TempData["State"] = Request.Form["State"]; 
            TempData["Zip"] = Request.Form["Zip"];
            TempData["County"] = Request.Form["County"]; 
            TempData["Email"] = Request.Form["Email"];
            return RedirectToAction("PRG");
        }

        //
        // get: /Home/PRG
        /// <summary>
        ///  Thank you Page (GET-POST-Redirect)
        /// </summary>
        /// <returns>PRG View()</returns>
        public ActionResult PRG()
        {
            ViewBag.CID = TempData["CID"];
            ViewBag.DOB = TempData["DOB"];
            ViewBag.Name = TempData["Name"];
            ViewBag.Address = TempData["Address"];
            ViewBag.City = TempData["City"];
            ViewBag.State = TempData["State"];
            ViewBag.Zip = TempData["Zip"];
            ViewBag.County = TempData["County"];
            ViewBag.Email = TempData["Email"];
            return View();
        }
    }
}
