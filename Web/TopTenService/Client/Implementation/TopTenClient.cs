using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopTenService.Client.Interface;


namespace TopTenService.Client.Implementation
{
    

    public class TopTenClient : BaseSvcClient, ITopTenClient
    {
        public TopTenClient(IUrlProvider provider) : base(provider, UrlMappings.Regions.Controller)
        {
        }
        public SummaryResponse GetResults(TopTenRequest request)
        {
            var response = Post<SummaryRequest, SummaryResponse>(request, UrlMappings.Regions.GetReportbyRegion, TypeContent.AddJsonBody);

            if (response != null && response.Success)
            {
                return response.Data;
            }
            else
            {
                return new SummaryResponse();
            }
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        
    }
}
