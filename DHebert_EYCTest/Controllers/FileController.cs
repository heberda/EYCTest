using System;
using System.Linq;
using System.Web.Mvc;

namespace DHebert_EYCTest.Controllers
{
    public class FileController : Controller
    {
        
        public ActionResult SpecSheet()
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + "\\App_Data\\Programming Exercise EYC.docx";
            byte[] filedata = System.IO.File.ReadAllBytes(path);
            
            var cd = new System.Net.Mime.ContentDisposition
            {
                FileName = "Programming Exercise EYC.docx", 

                Inline = false,
            };
            Response.AppendHeader("Content-Disposition", cd.ToString());
            return File(filedata, "application/msword");
        }
	}
}