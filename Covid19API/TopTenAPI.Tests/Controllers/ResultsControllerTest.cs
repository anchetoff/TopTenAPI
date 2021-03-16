
using Microsoft.VisualStudio.TestTools.UnitTesting;

using TopTenAPI.Controllers;

using TopTenAPI.Common;
using TopTenAPI.Implementation;

namespace TopTenAPI.Tests.Controllers
{
    [TestClass]
    public class ResultsControllerTest
    {
        [TestMethod]
        public void Get()
        {
        }

        [TestMethod]
        public void GetById()
        {
        }

        [TestMethod]
        public void Post()
        {
            ResultsService service = new ResultsService();
            SummaryRequest request = new SummaryRequest("https://", "covid-19-statistics.p.rapidapi.com", 
                                                        "/reports", "986f4e3cecmsh3a8392b90cc0522p1c4047jsnd2bccb165147");
            request.IsoCode = ""; // To test service to obtain GetRegions top 10 leave empty ISO Country code parameter
            request.TotalResults = 10;

            RegionsController controller = new RegionsController(service);
            var resultsRegions = controller.GetResults(request);

            request.IsoCode = "USA"; //To test service to obtain GetProvinces top 10 by Country just put ISO country Code 
            var resultsProvinces = controller.GetResults(request);

        }

        [TestMethod]
        public void Put()
        {
            // Disponer
           // RegionsController controller = new RegionsController();

            // Actuar
            //controller.Put(5, "value");

            // Declarar
        }

        [TestMethod]
        public void Delete()
        {
            // Disponer
          //  RegionsController controller = new RegionsController();

            // Actuar
          //  controller.Delete(5);

            // Declarar
        }
    }
}
