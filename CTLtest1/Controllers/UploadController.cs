using CTLtest1.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Web.Http;
using System.Web.Mvc;

namespace CTLtest1.Controllers
{
    public class UploadController : Controller
    {

        public ActionResult Index()
        {
            ViewBag.Title = "Uploaded";

            return View();
        }

        public async System.Threading.Tasks.Task<ActionResult> UploadAsync(List<Order> data)
        {
            
            string jsonString = "";

            foreach (Order order in data)
            {
                jsonString += JsonConvert.SerializeObject(data);
            }
           
            //normally this url would be stored in web.config or a tool like octopus
            var actionUrl = "http://api-test.ctlglobalsolutions.com";
            await ApiInteractor.Upload(actionUrl, jsonString);
            return View();
        }


    }
}