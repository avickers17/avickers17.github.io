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

        // GET: API Makes a Get Request to giphy.com and returns json data
        [HttpGet]
        public JsonResult Picture(string id)
        {
            //get my apiKey for giphy
            string apiKey = System.Web.Configuration.WebConfigurationManager.AppSettings["CS460EmailConfirmationKey"];
            
            //build URL for GET request to giphy, including my key and url parameter
            string urlInfo = "https://api.giphy.com/v1/stickers/translate?api_key=" + apiKey + "&s=" + id;
            
            //Make a request using my urlInfo, then grab response information
            WebRequest request = WebRequest.Create(urlInfo);
            WebResponse response = request.GetResponse();
            Stream information = response.GetResponseStream();
            StreamReader reader = new StreamReader(information);

            //Grab full response information, read to the end of the data and put it into a string
            string responseString = reader.ReadToEnd();

            //Parse through the JSON object 
            var jsonSerialize = new System.Web.Script.Serialization.JavaScriptSerializer();
            var data = jsonSerialize.DeserializeObject(responseString);

            //create a database search object based on the GET request user information
            Search logItem = new Search();
            logItem.SearchPhrase = id;
            logItem.IpAddress = Request.UserHostAddress;
            logItem.Browser = Request.UserAgent;

            //Log and Save the request to the DB
            db.Searches.Add(logItem);
            db.SaveChanges();

            //Close the streams
            reader.Close();
            information.Close();
            response.Close();

            //Return JSON obj back to javascript for display purposes
            return Json(data, JsonRequestBehavior.AllowGet);
        }
    }
}