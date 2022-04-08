using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using MVCJson.Models;

namespace MVCJson.Controllers
{
    public class PersonController : Controller
    {
        // GET: Person
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(MPerson obj)
        {
            // Pass the "persondata" object for conversion to JSON string  
            string jsondata = new JavaScriptSerializer().Serialize(obj);            
            string path = Server.MapPath("~/App_Data/");
            // Write that JSON to txt file,  
            System.IO.File.WriteAllText(path + "jsonResult.json", jsondata);
            TempData["msg"] = "Json file Generated! Please check in App_Data folder";
            return RedirectToAction("Index");
        }
    }
}