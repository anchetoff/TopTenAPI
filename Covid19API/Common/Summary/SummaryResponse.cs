
using System.Collections.Generic;
using System.Runtime.Serialization;

using Newtonsoft.Json;

namespace TopTenAPI.Common
{
    [JsonObject(MemberSerialization.OptIn)]
    
    public class Summary //This class is reused to get values for Regions and Provinces, into code keeps unique value
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
        [JsonProperty]
        public int Code { get; set; }
        [JsonProperty]
        public string Message { get; set; }
    }
}