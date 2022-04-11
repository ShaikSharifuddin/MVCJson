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
            //string jsondata = new JavaScriptSerializer().Serialize(obj);            
            //string path = Server.MapPath("~/App_Data/");
            // Write that JSON to txt file,  
            //System.IO.File.WriteAllText(path + "jsonResult.json", jsondata);
            //TempData["msg"] = "Json file Generated! Please check in App_Data folder";
            //return RedirectToAction("Index");

            var filePath = Server.MapPath("~/App_Data/") + "jsonResult.json";
            // Read existing file json data if exist else its sets empty jsonstring
            var jsonData = "";
            if (System.IO.File.Exists(filePath))
            {
                jsonData = System.IO.File.ReadAllText(filePath);
            }
            //Deserializing the exising jsondata into a person list if data exist, else we are assigning a empty Person list.
            var personList = new JavaScriptSerializer().Deserialize<List<MPerson>>(jsonData) ?? new List<MPerson>();
            // Adding new person data to the list
            personList.Add(obj);
            // Pass the personlist object for conversion to JSON string  
            jsonData = new JavaScriptSerializer().Serialize(personList);
            //Writing to JSon file.
            System.IO.File.WriteAllText(filePath, jsonData);

            //Redirecting to HTTPGet Index method by passing the information.
            TempData["msg"] = "Json file Created! Please check in App_Data folder.";
            return RedirectToAction("Index");
        }
    }
}