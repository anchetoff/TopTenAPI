
using System.Web.Http;
using System.Web.Http.Description;

using TopTenAPI.Common;


using TopTenAPI.ApiProperties;
using TopTenAPI.Interfaces;

namespace TopTenAPI.Controllers
{
    [RoutePrefix(UrlMappings.Regions.Controller)]
    public class RegionsController : ApiController
    {
        
        private readonly IResults _service;
        public RegionsController(IResults service)
        {
            _service = service;
           
        }
        // POST api/Regions/RptByRegions
        [HttpPost]
        [Route(UrlMappings.Regions.GetReportbyRegion)]
        [ResponseType(typeof(ApiResponse<SummaryResponse>))]
        public IHttpActionResult GetResults([FromBody] SummaryRequest request)
        {
            if(string.IsNullOrEmpty(request.IsoCode))
            {
                var response = _service.GetRegions(request);
                return Ok(response);
            }
            else
            {
                var response = _service.GetProvinces(request);
                return Ok(response);
            }
            
        }

        // POST api/values
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
