using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;


namespace MVC_Project.Controllers
{
    //********************************************
    /// <summary>
    /// The Home Controller
    /// </summary>
    /// <creator>
    /// Daniel Tapia
    /// </creator>
    /// <date>
    /// 11/06/17
    /// </date>
    //********************************************
    public class HomeController : Controller
    {
        // GET: /Home/
        /// <summary>
        /// This is the Home Page
        /// </summary>
        /// <returns>Home</returns>
        public ActionResult Index()
        {
            var mvcName = typeof(Controller).Assembly.GetName();
            var isMono = Type.GetType("Mono.Runtime") != null;

            ViewData["Version"] = mvcName.Version.Major + "." + mvcName.Version.Minor;
            ViewData["Runtime"] = isMono ? "Mono" : ".NET";


            Debug.WriteLine("This is Home");

            return View();
        }

        // GET: /Home/Page1/
        /// <summary>
        /// Directs you to View of Page 1
        /// </summary>
        /// <returns>Page1</returns>
        public ActionResult Page1()
        {
            return View();
        }

        // GET: /Home/TheBank/
        /// <summary>
        /// This is The Bank Where we can convert 
        /// USD to Mexican Peso; Mexican Peso to USD.
        /// </summary>
        /// <returns>TheBank</returns>
        public ActionResult TheBank()
        {
            string USD = Request.QueryString["USD"];
            string MP = Request.QueryString["MP"];

            if (!string.IsNullOrEmpty(USD))
            {
                int US = int.Parse(USD);
                //US to MP is around 19.26 a Dollar as of November 2017
                ViewBag.MP = Math.Round((US * 19.264299), 2).ToString();
                return View();
            }
            if (!string.IsNullOrEmpty(MP))
            {
                int MX = int.Parse(MP);
                //MP to USD is around 0.052 a Peso as of November 2017
                ViewBag.USD = Math.Round((MX * 0.051946), 2).ToString();
                return View();
            }
            return View();
        }



        // Get: /Home/Page2/
        /// <summary>
        /// Using HttpGet to get info from user
        /// </summary>
        /// <returns>Page2</returns>
        [HttpGet]
        public ActionResult Page2()
        {
            return View();
        }

        // POST: /Home/Page2/
        /// <summary>
        /// Retrieves information from using
        /// Using HttpPost and FormCollection
        /// </summary>
        /// <returns>Page2</returns>
        /// <param name="form">Request Information</param>
        [HttpPost]
        public ActionResult Page2(FormCollection form)
        {
            if (!(IsNUll(form)))
            {
                int Length = int.Parse(Request.Form["Length"]);
                int Width = int.Parse(Request.Form["Width"]);
                int Height = int.Parse(Request.Form["Height"]);

                //Volume = Length * Width * Height
                int Volume = Length * Width * Height; 
                ViewBag.Volume = Volume.ToString();

                ViewBag.Length = Length;
                ViewBag.Width = Width;
                ViewBag.Height = Height;

                return View("Page2");
            }
            return View("Page2");
        }

        /// <summary>
        /// Checks if FormCollection Form is NULL
        /// </summary>
        /// <returns>
        /// <c>true</c>, if true, Length, Width, or Height is empty or null.
        /// <c>false</c> otherwise, no empty values .
        /// </returns>
        /// <param name="form">User Values.</param>
        private bool IsNUll(FormCollection form)
        {
            string L = Request.Form["Length"];
            string W = Request.Form["Width"];
            string H = Request.Form["Height"];

            if (string.IsNullOrEmpty(L) || string.IsNullOrEmpty(W) || string.IsNullOrEmpty(H))
            {
                ViewBag.IsNull = "true";
                return true;
            }
            else
            {
                ViewBag.IsNull = "false";
                return false;
            }
        }



        /// <summary>
        /// GET user info
        /// </summary>
        /// <returns>Page3</returns>
        [HttpGet]
        public ActionResult Page3()
        {
            return View();
        }

        /// <summary>
        /// Loan Calculator
        /// </summary>
        /// <credit>
        /// https://www.thebalance.com/loan-payment-calculations-315564
        /// </credit>
        /// <returns>MonthlyPay</returns>
        /// <param name="amount">Loan Amount.</param>
        /// <param name="rate">Interest Rate.</param>
        /// <param name="time">Months.</param>
        [HttpPost]
        public ActionResult Page3(double? amount, double? rate, double? time)
        {

            double Amount = (double)amount;
            double Rate = (double)((double)(rate / 100) / time); //Annual Rate
            double Time = (double)time;

            //Discount Factor
            double Factor = (Math.Pow((1 + Rate), Time) - 1) / (Rate * (Math.Pow((1 + Rate), Time)));

            double MonPay = Amount / Factor; //Monthly Pay
            double IntPay = (MonPay * Time) - Amount; //Period Rate
            double Total = Amount + IntPay; //Total Cost

            ViewBag.Amount = String.Format("{0:n}", Amount);
            ViewBag.Rate = Math.Round(Rate, 5);
            ViewBag.Time = Time;
            ViewBag.Total = String.Format("{0:n}", Total);
            ViewBag.MonPay = String.Format("{0:n}", MonPay);
            ViewBag.IntPay = String.Format("{0:n}", IntPay);

            return View("MonthlyPay");
        }

        /// <summary>
        /// Results
        /// </summary>
        /// <returns>Monthly Payment Page</returns>
        public ActionResult MonthlyPay()
        {
            return View();
        }
    }
}
