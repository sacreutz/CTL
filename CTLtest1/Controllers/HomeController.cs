using CsvHelper;
using CTLtest1.Models;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CTLtest1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();


        }

        public ActionResult RedirectDfAction(string myFile)
        {
 

                var dataFile = System.Web.Hosting.HostingEnvironment.MapPath("~/") + "\\Files\\" + myFile;

                //csvReader is a nuget package 
                var csvTable = new DataTable();
                using (var csvReader = new CsvReader(new StreamReader(System.IO.File.OpenRead(dataFile)), System.Globalization.CultureInfo.CurrentCulture))
                {
                    csvTable.Load((IDataReader)csvReader);
                }                
                
 
                List<Order> list = new List<Order>();

                for (int i = 0; i < csvTable.Rows.Count; i++)
                {
                    list.Add(new Order { FirstName = csvTable.Rows[i][0].ToString(), LastName = csvTable.Rows[i][1].ToString(), Addr1 = csvTable.Rows[i][2].ToString(),
                                          City = csvTable.Rows[i][3].ToString(), State = csvTable.Rows[i][4].ToString(), Postal = (long)csvTable.Rows[i][5], 
                                           SKU = csvTable.Rows[i][6].ToString(), Quantity = (long)csvTable.Rows[i][7]});
                }


                ViewBag.Data = list;
                return View("Upload");

        }

    }
}
