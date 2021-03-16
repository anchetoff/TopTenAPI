using Newtonsoft.Json;

namespace TopTenService.Client
{
    [JsonObject(MemberSerialization.OptIn)]
    public class TopTenRequest
    {
        const int defaultValue = 10;
        public string Host{ get; set; }
        public string Method{ get; set; }
        public string ApiKey{ get;set; }
        public string Protocol { get; set; }

        public TopTenRequest(string protocol, string host, string method, string key)
        {
            Method = method;
            ApiKey = key;
            Host = host;
            Protocol = protocol;
            TotalResults = defaultValue;
        }

        [JsonProperty]
        public int TotalResults { get; set; }

        [JsonProperty]
        public string IsoCode { get; set; }

    }
}