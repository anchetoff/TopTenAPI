using TopTenAPI.Interfaces;
using TopTenAPI.Common;
using TopTenAPI.Common.Region;

using RestSharp;
using Newtonsoft.Json;

using System.Collections.Generic;
using System.Linq;

namespace TopTenAPI.Implementation
{
    public class ResultsService:IResults
    {
        public ResultsService()
        {
        }
        public SummaryResponse GetRegions(SummaryRequest request)
        {
            RestRequest requestRest = request.CreateRequest(); 
            

            var client = new RestClient(request.UrlCall());
            IRestResponse responseRest = client.Execute(requestRest);

            //Get all data cases by region
            Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(responseRest.Content);
            

            //Create group by ISO country code
            List<Summary> result = myDeserializedClass.data.ToList<Info>()
                                    .GroupBy(l => l.region.iso)
                                    .Select(cl => new Summary
                                    {
                                        Code = cl.First().region.iso,
                                        Name = cl.First().region.name,
                                        ConfirmedCases = cl.Sum(c => c.confirmed),
                                        DeathCases = cl.Sum(c => c.deaths)
                                    })
                                    .OrderByDescending(r => r.ConfirmedCases)
                                    .ToList();

            //Sort descending and top 10 defined into request.TotalResults
            var orderByDescendingResult = (from r in result
                                           orderby r.ConfirmedCases descending
                                           select r).Take(request.TotalResults).ToList<Summary>();

            
            var response = new SummaryResponse();

            if (responseRest.IsSuccessful)
            {
                response.Summaries = orderByDescendingResult;
                response.Code = (int)responseRest.StatusCode;
                response.Message = responseRest.StatusDescription;
            }
            else
            {
                response.Summaries = null;
                response.Code = (int)(responseRest.StatusCode);
                response.Message = responseRest.ErrorMessage;
            }

            return response;
        }
        public SummaryResponse GetProvinces(SummaryRequest request)
        {
            RestRequest requestRest = request.CreateRequest();


            var client = new RestClient(request.UrlCall());
            IRestResponse responseRest = client.Execute(requestRest);

            //Get all data cases by region
            Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(responseRest.Content);


            //Create filter by ISO code country
            List<Info> result = myDeserializedClass.data.ToList<Info>()
                                    .FindAll(x => x.region.iso == request.IsoCode);
                                    
                                    var provinces = result.Select(cl => new Summary
                                    {
                                        Code = cl.region.iso + "-" + cl.region.province,
                                        Name = cl.region.province,
                                        ConfirmedCases = cl.confirmed,
                                        DeathCases = cl.deaths
                                    })
                                    .OrderByDescending(r => r.ConfirmedCases)
                                    .ToList();

            //Sort descending and get only top 10 (request.TotalResults)
            var orderByDescendingResult = (from r in provinces
                                           orderby r.ConfirmedCases descending
                                           select r).Take(request.TotalResults).ToList<Summary>();


            var response = new SummaryResponse();

            if (responseRest.IsSuccessful)
            {
                response.Summaries = orderByDescendingResult;
                response.Code = (int)responseRest.StatusCode;
                response.Message = responseRest.StatusDescription;
            }
            else
            {
                response.Summaries = null;
                response.Code = (int)(responseRest.StatusCode);
                response.Message = responseRest.ErrorMessage;
            }

            return response;
        }
    }
}