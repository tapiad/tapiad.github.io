using ArtGallery.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace ArtGallery.Controllers
{
    public class HomeController : Controller
    {
        ArtContext db = new ArtContext();

        // GET: Home
        public ActionResult Index()
        {
            var genres = db.Genres.ToList();
            return View(genres);
        }

        // GET: Home/Artists
        public ActionResult Artists()
        {
            List<Artist> artists = db.Artists.ToList();
            return View(artists);
        }

        // GET: Home/ArtWorks
        public ActionResult ArtWorks()
        {
            var works = db.ArtWorks.ToList();
            return View(works);
        }

        // GET: Home/Classifications
        public ActionResult Classifications()
        {
            var classifications = db.Genres.ToList();
            return View(classifications);
        }

        // GET: Home/ArtistDetails/{Artist Name}
        public ActionResult ArtistDetails(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Artist artist = db.Artists.Find(id);
            if (artist == null)
            {
                return HttpNotFound();
            }
            return View(artist);
        }

        // GET: Home/CreateArtist
        [HttpGet]
        public ActionResult CreateArtist()
        {
            return View();
        }

        // POST: Home/CreateArtist
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateArtist([Bind(Include = "Name, BirthDate, BirthCity")] Artist artist)
        {
            if (ModelState.IsValid)
            {
                db.Artists.Add(artist);
                db.SaveChanges();
                return RedirectToAction("Artists");
            }
            return View(artist);
        }    

        // GET: Home/EditArtist/{artist name}
        [HttpGet]
        public ActionResult EditArtist(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Artist artist = db.Artists.Find(id);
            if (artist == null)
            {
                return HttpNotFound();
            }
            return View(artist);
        }

        // POST: Home/EditArtist/{artist name}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditArtist([Bind(Include = "Name, BirthDate, BirthCity")] Artist artist)
        {
            if (ModelState.IsValid)
            {
                db.Entry(artist).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Artists");
            }
            return View(artist);
        }

        // GET: Home/DeleteArtist/{artist name}
        [HttpGet]
        public ActionResult DeleteArtist(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Artist artist = db.Artists.Find(id);
            if (artist == null)
            {
                return HttpNotFound();
            }
            return View(artist);
        }

        //POST: Home/DeleteArtist/{artist name}
        [HttpPost, ActionName("DeleteArtist")]
        public ActionResult DeleteArtistConfirmed(string id)
        {
            Artist artist = db.Artists.Find(id);
            db.Artists.Remove(artist);
            db.SaveChanges();
            return RedirectToAction("Artists");
        }

        /// <summary>
        /// Takes string id to return a JSON Object
        /// </summary>
        /// <param name="id">Genre Name</param>
        /// <returns>JSON Object</returns>
        public JsonResult GenreDetails(string id)
        {
            //Data  EX: 'Portrait'
            var data = db.Genres.Where(g => g.Name == id)//'Protrait' == 'Portrait'
                                 .Select(s => s.ArtWorks)//Select:'Mono Lisa' from colomn 'Artwork'
                                 .FirstOrDefault() //First element of sequence or defualt value
                                 .Select(s => new { s.Title, s.Artist })//Select: 'Title' & 'Artist' from 'ArtWork' table 
                                 .OrderBy(o => o.Title)
                                 .ToList();
            //return as a Json object
            return Json(data, JsonRequestBehavior.AllowGet);
        }
    }
}