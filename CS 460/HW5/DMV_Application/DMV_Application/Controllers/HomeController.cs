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
        private DMVContext db = new DMVContext();

        //public void ConfigureServices(IServiceCollection services)
        //{
        //    // Add framework services.
        //    services.AddMvc();

        //    services.AddDbContext<DMVContext>(options =>
        //            options.UseSqlite("Data Source=DMV_Application.db"));

        //}

        public ActionResult Index()
        {

            return View ();
        }
         
        public ActionResult Requests()
        {
            return View(db.DMVRequest.ToList());
        }

        public ActionResult ChangeAdd()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ChangeAdd(FormCollection form)
        {
            TempData["CID"] = Request.Form["CID"];
            return RedirectToAction("PRG");
        }
    
        public ActionResult PRG()
        {
            ViewBag.CID = TempData["CID"];
            return View();
        }
    }
}
