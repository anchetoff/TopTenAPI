
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;


namespace TopTenService.Client
{
    [JsonObject(MemberSerialization.OptIn)]
    
    public class Summary
    {
        
        public Summary() { }
        [JsonProperty]
        public string Code { get; set; }
        [JsonProperty]
        public string Name { get; set; }
        [JsonProperty]
        public int ConfirmedCases { get; set; }
        [JsonProperty]
        public int DeathCases { get; set; }
    }
    [JsonObject(MemberSerialization.OptIn)]
    [KnownType(typeof(SummaryResponse))]
    public class SummaryResponse
    {
        public SummaryResponse() { }
        [JsonProperty]
        public List<Summary> Summaries { get; set; }
        
    }

    [JsonObject(MemberSerialization.OptIn)]
    [KnownType(typeof(SummaryRequest))]
    public class SummaryRequest: APIConnection
    {
        public SummaryRequest() { }
        public SummaryRequest(string protocol, string host, string method, string key) : base()
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

    }

    public class TopTenResponse<T>
    {
        [JsonProperty]
        public T Data { get; set; }
        [JsonProperty]
        public ErrorResponse Error { get; set; }
        [JsonProperty]
        public string Message { get; set; }
        [JsonProperty]
        public bool Success { get; set; }
    }

    public class ErrorResponse
    {
        public ErrorResponse()
        {
        }
        public ErrorResponse(string message)
        {
            Message = message;
        }
        public string Message { get; set; }
    }
}