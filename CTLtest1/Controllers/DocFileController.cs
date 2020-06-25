using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web;
using System.IO;
namespace FileUpload.Controllers
{
    public class DocFileController : ApiController
    {
        //public HttpResponseMessage Post()
        //{
        //    HttpResponseMessage result = null;
        //    var httpRequest = HttpContext.Current.Request;
        //    if (httpRequest.Files.Count > 0)
        //    {
        //        var docfiles = new List<string>();
        //        foreach (string file in httpRequest.Files)
        //        {
        //            var postedFile = httpRequest.Files[file];
        //            var filePath = HttpContext.Current.Server.MapPath("~/" + postedFile.FileName);
        //            postedFile.SaveAs(filePath);
        //            docfiles.Add(filePath);
        //        }
        //        result = Request.CreateResponse(HttpStatusCode.Created, docfiles);
        //    }
        //    else
        //    {
        //        result = Request.CreateResponse(HttpStatusCode.BadRequest);
        //    }
        //    return result;
        //}

        [HttpPost()]
        public string UploadFiles()
        {
            int iUploadedCnt = 0;

            // DEFINE THE PATH WHERE WE WANT TO SAVE THE FILES.
            string sPath = "";
            sPath = System.Web.Hosting.HostingEnvironment.MapPath("~/");

            System.Web.HttpFileCollection hfc = System.Web.HttpContext.Current.Request.Files;

            // CHECK THE FILE COUNT.
            for (int iCnt = 0; iCnt <= hfc.Count - 1; iCnt++)
            {
                System.Web.HttpPostedFile hpf = hfc[iCnt];

                if (hpf.ContentLength > 0)
                {
                    // CHECK IF THE SELECTED FILE(S) ALREADY EXISTS IN FOLDER. (AVOID DUPLICATE)
                    //    if (!File.Exists(sPath + Path.GetFileName(hpf.FileName)))
                    //    {
                    // SAVE THE FILES IN THE FOLDER.
                        string sPathFinal = sPath + "\\Files\\";
                        hpf.SaveAs(sPathFinal + Path.GetFileName(hpf.FileName));
                        iUploadedCnt = iUploadedCnt + 1;
                //    }
                }
            }

            if (iUploadedCnt > 0)
            {
                //  return iUploadedCnt + " File(s) Uploaded Successfully";
                return hfc[0].FileName;
              //  return this.RedirectToAction("Notification", "DealCards", new { CheckUser = User }});
             }
            else
            {
                return "Upload Failed";
            }
        }
    }
}