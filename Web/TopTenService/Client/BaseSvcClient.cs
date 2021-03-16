using RestSharp;
using TopTenService.Client.Interface;

namespace TopTenService.Client
{
    public enum TypeContent
    {
        AddBody,
        AddJsonBody,
        AddObject
    }

    public class BaseSvcClient : IServiceClient
    {
        private readonly IRestClient _client;

        private string ControllerRoute { get; set; }

        public BaseSvcClient(IUrlProvider provider, string route)
        {
            _client = new RestClient(provider.GetUrl(route));
            ControllerRoute = route;
        }

        public TopTenResponse<TResponse> Post<TRequest, TResponse>(TopTenRequest request, string action, TypeContent typeContent = TypeContent.AddObject) where TResponse : new()
        {
            var restRequest = PrepareRequest<TRequest>(request, action, Method.POST, typeContent);
            var response = _client.Post<TopTenResponse<TResponse>>(restRequest);

            if (response.IsSuccessful)
            {
                response.Data.Message = response.StatusDescription;
            }
            else
            {
                response.Data.Error.Message = response.StatusDescription;
            }
            return response.Data;
        }

        public TopTenResponse<TResponse> Get<TRequest, TResponse>(TopTenRequest request, string action) where TResponse : new()
        {
            var restRequest = PrepareRequest<TRequest>(request, action, Method.GET);
            var restResponse = _client.Get<TopTenResponse<TResponse>>(restRequest);

            if (restResponse.ResponseStatus == ResponseStatus.Completed)
            {
                return restResponse.Data;
            }
            else
            {
                return new TopTenResponse<TResponse>()
                {
                    Data = default,
                    Error = new ErrorResponse()
                    {
                        Message = restResponse?.ErrorMessage + "\n" + restResponse.ErrorException.Message
                    },
                    Success = false
                };
            }
        }
        public TopTenResponse<TResponse> Put<TRequest, TResponse>(TopTenRequest request, string action) where TResponse : new()
        {
            var restRequest = PrepareRequest<TRequest>(request, action, Method.PUT);

            return _client.Put<TopTenResponse<TResponse>>(restRequest).Data;
        }
        public TopTenResponse<TResponse> Patch<TRequest, TResponse>(TopTenRequest request, string action) where TResponse : new()
        {
            var restRequest = PrepareRequest<TRequest>(request, action, Method.PATCH);

            return _client.Patch<TopTenResponse<TResponse>>(restRequest).Data;
        }
        public TopTenResponse<TResponse> Delete<TRequest, TResponse>(TopTenRequest request, string action) where TResponse : new()
        {
            var restRequest = PrepareRequest<TRequest>(request, action, Method.DELETE);

            return _client.Delete<TopTenResponse<TResponse>>(restRequest).Data;
        }

        private IRestRequest PrepareRequest<TRequest>(TopTenRequest request, string action, Method httpMethod, TypeContent typeContent = TypeContent.AddObject)
        {
            var restRequest = new RestRequest(action);
            restRequest.Method = httpMethod;
            switch (typeContent)
            {

                case TypeContent.AddObject:
                    restRequest.AddObject(request);
                    break;
                case TypeContent.AddJsonBody:
                    restRequest.AddJsonBody(request);
                    break;
                case TypeContent.AddBody:
                    restRequest.AddBody(request);
                    break;
                default:
                    restRequest.AddObject(request);
                    break;
            }
            restRequest.RequestFormat = DataFormat.Json;
            return restRequest;
        }

    }
}
