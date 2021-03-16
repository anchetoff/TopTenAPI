using TopTenAPI.Common;

using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;

namespace TopTenAPI
{
    public class WrapHandler : DelegatingHandler
    {

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage req, CancellationToken canxTkn)
        {
            var resp = await base.SendAsync(req, canxTkn);
            return BuildApiResponse(req, resp);
        }

        private static HttpResponseMessage BuildApiResponse(HttpRequestMessage req, HttpResponseMessage resp)
        {
            string errMsg = null;

            if(resp.TryGetContentValue(out object content) && !resp.IsSuccessStatusCode)
            {
                if(content is HttpError err)
                {
                    content = null;
                    errMsg = err.Message;
                }                
            }

            var wrapper = new ApiResponse<object>(resp.IsSuccessStatusCode, content, errMsg);
            var finalResponse = req.CreateResponse(resp.StatusCode, wrapper);

            foreach (var header in resp.Headers) finalResponse.Headers.Add(header.Key, header.Value);

            return finalResponse;
        }
    }

}