using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TopTenAPI.ApiProperties
{
    public static class UrlMappings
    {
        public static class Regions
        {
            public const string Controller = "Regions";
            
            public const string ExternalReportApi = "reports"; // Call to url API method
            public const string GetReportbyRegion = "RptByRegions";
        }

    }
}