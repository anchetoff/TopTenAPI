using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml;
using System.Xml.Linq;
using Newtonsoft.Json;
using Top10Covid19.Models;
using TopTenService.Client;
using TopTenService.Client.Implementation;
using TopTenService.Client.Interface;

namespace Top10Covid19.Controllers
{
    public class HomeController : Controller
    {
        ApiSettingsProvider settings;
        ITopTenClient client;
        public HomeController()
        {
            settings = new ApiSettingsProvider();
            client = new TopTenClient(settings);
        }
        
        public ActionResult Index()
        {
            
            

           

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpPost]
        public JsonResult GetResults(string isoCode)
        {
            TopTenRequest request = new TopTenRequest(settings.GetKey("protocolCovid19API"), settings.GetKey("hostCovid19API"),
                                                      settings.GetKey("methodCovid19API"), settings.GetKey("ApiKeyCovid19API"));
            request.TotalResults = 10;
            
            if(!string.IsNullOrEmpty(isoCode))request.IsoCode = isoCode; //This parameter is used to get provinces values, otherwise will load as region
            var regionResults = client.GetResults(request);

            JsonResponse<Summary> response = new JsonResponse<Summary>();
            response.data = regionResults.Summaries;
            if (string.IsNullOrEmpty(request.IsoCode))
            {
                response.regions = regionResults.Summaries.Select<Summary,RegionModel>(x => new RegionModel { Code= x.Code, Name= x.Name })
                                                           .OrderBy(x => x.Name)
                                                           .ToList<RegionModel>();   
            }

            return Json(response, JsonRequestBehavior.DenyGet);
        }

        [HttpPost]
        public ActionResult JsonToXml(string data)
        {
            XmlDocument doc = JsonConvert.DeserializeXmlNode(data,"root");

            var newStream = new System.IO.MemoryStream();
            var writer = new System.IO.StreamWriter(newStream);
            writer.Write(doc.OuterXml);
            writer.Flush();
            newStream.Position = 0;

            return File(newStream, "application/xml", "file.xml");
        }

    }
}