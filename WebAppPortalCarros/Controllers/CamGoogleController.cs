using Google.Cloud.Vision.V1;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using WebAppPortalCarros.Models;

namespace WebAppPortalCarros.Controllers
{
    public class CamGoogleController : Controller
    {
        [HttpGet]
        public ActionResult Capture()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Capture(FileUpload fileObj)
        {

            var response = "";
            var fileBytes = "";
            var img = new FileUpload();
            //foreach (var file in Request.Form.Files)
            //{
            //    if (file.Length > 0)
            //    {
            //        using (var ms = new MemoryStream())
            //        {
            //            file.CopyTo(ms);
            //            fileBytes = ms.ToArray();
            //        }
            //    }
            //    var imageParts = fileBytes.Split(',').ToList<string>();
            //}

            if (fileObj.File.Length > 0)
            {
                using (var ms = new MemoryStream())
                {
                    fileObj.File.CopyTo(ms);
                    fileBytes = ms.ToString();
                    ms.Close();
                    ms.Dispose();
                }
                var imageParts = fileBytes.Split(',').ToList<string>();
                //byte[] imageBytes = Convert.FromBase64String(imageParts[1]);
                using (var client = new WebClient())
                {
                    Mainrequests Mainrequests = new Mainrequests()
                    {
                        requests = new List<requests>()
                        {
                            new requests()
                            {
                                image = new image()
                                {
                                    content = imageParts[1]
                                },
                                features = new List<features>()
                                {
                                    new features()
                                    {
                                        type = "LABEL_DETECTION",
                                    }
                                }
                            }
                        }
                    };
                    var uri = "https://vision.googleapis.com/v1/images:annotate?key=" + "AIzaSyBhPq2NwiWUE0cUGF8c6JRG9uhXFwzUlJ4";
                    //chave myrella AIzaSyBhPq2NwiWUE0cUGF8c6JRG9uhXFwzUlJ4
                    client.Headers.Add("Content-Type:application/json");
                    client.Headers.Add("Accept:application/json");
                    response = client.UploadString(uri, JsonConvert.SerializeObject(Mainrequests));
                }
            }
            return Json(data: response);
        }

        //public ActionResult Capture(FileUpload fileObj)
        //{
        //    var texto = "";
        //    var client = ImageAnnotatorClient.Create();
        //    var image = Image.FromUri("gs://cloud-vision-codelab/otter_crossing.jpg");
        //    var response = client.DetectText(image);
        //    foreach (var annotation in response)
        //    {
        //        if (annotation.Description != null)
        //        {
        //            texto = annotation.Description;
        //        }
        //    }
        //    return Json(texto, JsonRequestBehavior.AllowGet);
        //}
    }
}
