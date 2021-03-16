using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using TopTenAPI.ApiProperties;
using RestSharp;
using Newtonsoft.Json;

namespace TopTenAPI.Common
{
    [JsonObject(MemberSerialization.OptIn)]
    public class SummaryRequest : APIConnection
    {

        public SummaryRequest(string protocol, string host, string method, string key):base()
        {
            Method = method;
            ApiKey = key;
            Host = host;
            Protocol = protocol;
        }

        [JsonProperty]
        public int TotalResults { get; set; }

        [JsonProperty]
        public string IsoCode { get; set; }

        public RestRequest CreateRequest()
        {
            var request = new RestRequest(RestSharp.Method.GET);
            request.AddHeader("x-rapidapi-key", ApiKey);
            request.AddHeader("x-rapidapi-host", Host);
            request.RequestFormat = DataFormat.Json;
            return request;
        }
    }
}