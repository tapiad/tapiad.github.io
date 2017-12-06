using AuctionHouse.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace AuctionHouse.Controllers
{
    public class HomeController : Controller
    {

        //AuctionContext db = new AuctionContext();

        public ActionResult Index()
        {
            return View();
        }
    }

    //// GET: Home/ItemDetails/{id}
    //public ActionResult ItemDetails(int? id)
    //{
    //    if (id == null)
    //    {
    //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
    //    }
    //    Item artist = db.Items.Find(id);
    //    if (artist == null)
    //    {
    //        return HttpNotFound();
    //    }
    //    return View(item);
    //    //Debug.WriteLine("ArtistName = " + id);
    //    //Artist artist = db.Artists.Find(id);
    //    //Debug.WriteLine("artist.Name = " + artist.Name);
    //    //return View(artist);
    //}

    //// GET: Home/CreateItem
    //[HttpGet]
    //public ActionResult CreateItem()
    //{
    //    return View();
    //}

    //// POST: Home/CreateItem
    //[HttpPost]
    //[ValidateAntiForgeryToken]
    //public ActionResult CreateItem([Bind(Include = "ID, Name, Description, Seller")] Item item)
    //{
    //    if (ModelState.IsValid)
    //    {
    //        db.Items.Add(item);
    //        db.SaveChanges();
    //        return RedirectToAction("Items");
    //    }
    //    return View(item);
    //}

    //// GET: Home/EditItem/{id}
    //[HttpGet]
    //public ActionResult EditItem(int? id)
    //{
    //    if (id == null)
    //    {
    //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
    //    }
    //    Item item = db.Items.Find(id);
    //    if (item == null)
    //    {
    //        return HttpNotFound();
    //    }
    //    return View(item);
    //    //Artist artist = db.Artists.Find(id);
    //    //return View(artist);
    //}

    //// POST: Home/EditItem/{id}
    //[HttpPost]
    //[ValidateAntiForgeryToken]
    //public ActionResult EditItem([Bind(Include = "ID, Name, Description, Seller")] Item item)
    //{
    //    if (ModelState.IsValid)
    //    {
    //        db.Entry(item).State = EntityState.Modified;
    //        db.SaveChanges();
    //        return RedirectToAction("Items");
    //    }
    //    return View(item);
    //}

    //// GET: Home/DeleteItem/{id}
    //[HttpGet]
    //public ActionResult DeleteItem(int? id)
    //{
    //    if (id == null)
    //    {
    //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
    //    }
    //    Items item = db.Items.Find(id);
    //    if (item == null)
    //    {
    //        return HttpNotFound();
    //    }
    //    return View(item);
    //    //Artist artist = db.Artists.Find(id);
    //    //return View(artist);
    //}

    ////POST: Home/DeleteItem/{id}
    //[HttpPost, ActionName("DeleteItem")]
    //public ActionResult DeleteItemConfirmed(int? id)
    //{
    //    Items item = db.Items.Find(id);
    //    db.Items.Remove(item);
    //    db.SaveChanges();
    //    return RedirectToAction("Items");
    //}
}