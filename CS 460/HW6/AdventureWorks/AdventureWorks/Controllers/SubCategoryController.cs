using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Diagnostics;
using System.Web.Mvc;
using AdventureWorks.Models;

namespace AdventureWorks.Controllers
{
    public class SubCategoryController : Controller
    {
        private AWContext db = new AWContext();

        // GET: SubCategory
        public ActionResult Index()
        {
            //Get Product Caregories
            var productSubcategories = db.ProductSubcategories.Include(p => p.ProductCategory);
            return View(productSubcategories.ToList());
        }


        //*****************************************Bikes*****************************************//


        // GET: SubCategory/Bikes
        public ActionResult Bikes()
        {
            //List of Bikes into ViewBag
            List<string> bikes = db.ProductSubcategories.Where(n => n.ProductCategory.Name == "Bikes").Select(sn => sn.Name).ToList();
            ViewBag.bikes = bikes;

            return View();
        }

        // POST: SubCategory/Bikes
        [HttpPost]
        public ActionResult Bikes(string bike)
        {
            //List of Bikes into ViewBag
            List<string> bikes = db.ProductSubcategories.Where(b => b.ProductCategory.Name == "Bikes").Select(n => n.Name).ToList();
            ViewBag.bikes = bikes;

            //Class "H" Bikes
            var products = db.Products.Where(b => b.ProductSubcategory.Name == bike
                                                    && b.Class == "H");
          
            if (products.Count() > 0)
            {
                return View(products);
            }
            return RedirectToAction("Bikes"); ;
        }


        //*****************************************Components*****************************************//


        // GET: SubCategory/Components
        public ActionResult Components()
        {
            //List of Components into ViewBag
            List<string> Components = db.ProductSubcategories.Where(n => n.ProductCategory.Name == "Components").Select(sn => sn.Name).ToList();
            ViewBag.Components = Components;

            return View();
        }

        // POST: SubCategory/Components
        [HttpPost]
        public ActionResult Components(string Component)
        {
            //List of Components into ViewBag
            List<string> Components = db.ProductSubcategories.Where(b => b.ProductCategory.Name == "Components").Select(n => n.Name).ToList();
            ViewBag.Components = Components;

            //Components products
            var products = db.Products.Where(b => b.ProductSubcategory.Name == Component
                                                    && b.FinishedGoodsFlag == true
                                                    && b.MakeFlag == true
                                                    && b.SellEndDate == null);

            if (products.Count() > 0)
            {
                return View(products);
            }
            return RedirectToAction("Components"); ;
        }


        //*****************************************Clothing*****************************************//


        // GET: SubCategory/Clothing
        public ActionResult Clothing()
        {
            //List of Clothing into ViewBag
            List<string> Clothing = db.ProductSubcategories.Where(n => n.ProductCategory.Name == "Clothing").Select(sn => sn.Name).ToList();
            ViewBag.Clothing = Clothing;

            return View();
        }

        // POST: SubCategory/Clothing
        [HttpPost]
        public ActionResult Clothing(string Cloth)
        {
            //List of Clothing into ViewBag
            List<string> Clothing = db.ProductSubcategories.Where(b => b.ProductCategory.Name == "Clothing").Select(n => n.Name).ToList();
            ViewBag.Clothing = Clothing;

            //Clothing products
            var products = db.Products.Where(b => b.ProductSubcategory.Name == Cloth       
                                                    && b.SellEndDate == null);

            if (products.Count() > 0)
            {
                return View(products);
            }
            return RedirectToAction("Clothing"); ;
        }


        //*****************************************Accessories*****************************************//


        // GET: SubCategory/Accessories
        public ActionResult Accessories()
        {
            //List of Accessories into ViewBag
            List<string> Accessories = db.ProductSubcategories.Where(n => n.ProductCategory.Name == "Accessories").Select(sn => sn.Name).ToList();
            ViewBag.Accessories = Accessories;

            return View();
        }

        // POST: SubCategory/Accessories
        [HttpPost]
        public ActionResult Accessories(string Accessory)
        {
            //List of Accessories into ViewBag
            List<string> Accessories = db.ProductSubcategories.Where(b => b.ProductCategory.Name == "Accessories").Select(n => n.Name).ToList();
            ViewBag.Accessories = Accessories;

            //Accessories products
            var products = db.Products.Where(b => b.ProductSubcategory.Name == Accessory
                                                    && b.SellEndDate == null);

            if (products.Count() > 0)
            {
                return View(products);
            }
            return RedirectToAction("Accessories"); ;
        }


        //*****************************************Product*****************************************//


        // GET: SubCategory/Product?id=<product id>
        public ActionResult Product()
        {
            //Get Product's ID
            if (Request.QueryString["id"] == null)
            {
                return RedirectToAction("Index");
            }

            //String to int
            int id = Convert.ToInt32(Request.QueryString["id"]);
            //Get specific product
            var product = db.Products.Where(p => p.ProductID == id).FirstOrDefault();
            //Product Model ID
            int? pmi = product.ProductModelID;
            //Description
            string desc = "Not Availiable";

            if (pmi != null)
            {
                //Product Description
                desc = db.ProductModelProductDescriptionCultures.Where(p => p.ProductModelID == pmi)
                                                                .FirstOrDefault().ProductDescription
                                                                .Description;
            }
            //Description into View
            ViewBag.desc = desc;

            //Product's image
            byte[] image = product.ProductProductPhotoes.FirstOrDefault().ProductPhoto.LargePhoto;
            //Product image into View
            ViewBag.image = "data:image/png;base64," + Convert.ToBase64String(image, 0, image.Length);

            return View(product);
        }


        //************************************Product*Review************************************//


        //GET : /Catalog/ProductReview?id=<product id>
        public ActionResult ProductReview()
        {
            string id = Request.QueryString["id"];
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            //Get specific product into View
            var product = db.Products.Where(p => p.ProductID.ToString() == id).FirstOrDefault();
            ViewBag.PID = id;
            ViewBag.PName = product.Name;
            //Get the product image
            byte[] image = product.ProductProductPhotoes.FirstOrDefault().ProductPhoto.LargePhoto;
            //Give the product image to the View
            ViewBag.image = "data:image/png;base64," + Convert.ToBase64String(image, 0, image.Length);

            return View();
        }

        //POST : /Catalog/ProductReview?id=<product id>
        //Enter the new review into the DB
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ProductReview([Bind(Include = "ProductReviewID, ProductID, ReviewerName, " +
            "ReviewDate, EmailAddress, Rating, Comments, CommentsModifiedDate, Product ")] ProductReview review)
        {
            string id = Request.QueryString["id"];
            if (id == null)
            {
                return RedirectToAction("Index");
            }

            //Get specific product
            var product = db.Products.Where(p => p.ProductID.ToString() == id).FirstOrDefault();
            //Get the product image
            byte[] image = product.ProductProductPhotoes.FirstOrDefault().ProductPhoto.LargePhoto;
            //Give the product image to the View
            ViewBag.image = "data:image/png;base64," + Convert.ToBase64String(image, 0, image.Length);
            ViewBag.PID = id;
            ViewBag.PName = product.Name;

            if (ModelState.IsValid)
            {
                //Set Values for Review
                review.ProductID = Convert.ToInt32(id);
                review.ReviewDate = DateTime.Now;
                review.ModifiedDate = review.ReviewDate;
                review.Product = db.Products.Where(p => p.ProductID.ToString() == id).FirstOrDefault();

                //Add & Save to DB
                db.ProductReviews.Add(review);
                db.SaveChanges();
                               
                return Redirect("/SubCategory/Product?id=" + id);
            }

            return View(review);
        }

    }
}
