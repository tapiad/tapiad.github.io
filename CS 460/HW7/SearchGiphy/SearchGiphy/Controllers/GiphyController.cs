using System;
using System.IO;
using System.Net;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace SearchGiphy.Controllers
{
    public class GiphyController : Controller
    {
        // GET: Giphy
        public ActionResult Index()
        {
            return View("~/Views/Home/Index.cshtml");
        }

        public JsonResult Search()
        {
            //Get Top Secret APIKey
            string key = System.Web.Configuration.WebConfigurationManager.AppSettings["GiphyAPIKey"];
            string q = Request.QueryString["q"]; //User's Input
            string rating = Request.QueryString["rating"]; //Rating prefrence
            string lang = Request.QueryString["lang"]; //Language

            //URL to Giphy API
            string url = "https://api.giphy.com/v1/gifs/search?q=" + q + "&api_key=" + key +
                "&limit=9&rating=" + rating + "&lang=" + lang;

            //Sends request to Giphy to get JSon
            WebRequest request = WebRequest.Create(url);            
            WebResponse response = request.GetResponse(); //The Response            
            Stream dataStream = response.GetResponseStream(); //Start Data Stream from Server.            
            string reader = new StreamReader(dataStream).ReadToEnd(); //Data Stream to a reader string

            //JSon string to a JSon object             
            var serializer = new JavaScriptSerializer();            
            var data = serializer.DeserializeObject(reader); //Deserialize string into JSon Object

            //Clean/Close Up
            response.Close();
            dataStream.Close();
            
            return Json(data, JsonRequestBehavior.AllowGet);
        }

    }
}