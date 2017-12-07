using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FinalProject.Models;

namespace FinalProject.Controllers
{

    public class HomeController : Controller
    {

        FinalContext db = new FinalContext();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Movies()
        {
            var movies = db.Movies.ToList();
            return View(movies);
        }

        public ActionResult Actors()
        {
            var actors = db.Actors.ToList();
            return View(actors);
        }

        public ActionResult Casts()
        {
            var casts = db.Movies.ToList();
            return View(casts);
        }

    }
}