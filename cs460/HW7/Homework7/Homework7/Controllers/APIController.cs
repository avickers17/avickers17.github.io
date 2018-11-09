using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Homework7.DAL;
using Homework7.Models;

namespace Homework7.Controllers
{
    public class APIController : Controller
    {

        private SearchesContext db = new SearchesContext();

        // GET: API
        [HttpGet]
        public JsonResult Picture(string id)
        {
         
            string apiKey = System.Web.Configuration.WebConfigurationManager.AppSettings["CS460EmailConfirmationKey"];
            string urlInfo = "https://api.giphy.com/v1/stickers/translate?api_key=" + apiKey + "&s=" + id;
            Debug.WriteLine(urlInfo);
            WebRequest request = WebRequest.Create(urlInfo);
            WebResponse response = request.GetResponse();

            Stream information = response.GetResponseStream();
            StreamReader reader = new StreamReader(information);

            string responseString = reader.ReadToEnd();

            var jsonSerialize = new System.Web.Script.Serialization.JavaScriptSerializer();
            var data = jsonSerialize.DeserializeObject(responseString);

            Search logItem = new Search();
            logItem.SearchPhrase = id;
            logItem.IpAddress = Request.UserHostAddress;
            logItem.Browser = Request.UserHostName;

            db.Searches.Add(logItem);
            db.SaveChanges();

            reader.Close();
            information.Close();
            response.Close();

            return Json(data, JsonRequestBehavior.AllowGet);

        }
    }
}