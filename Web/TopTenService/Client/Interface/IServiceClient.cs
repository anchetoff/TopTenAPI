
using TopTenService.Client.Implementation;


namespace TopTenService.Client.Interface
{
    public interface IServiceClient
    {
        TopTenResponse<TResponse> Post<TRequest, TResponse>(TopTenRequest request, string action, TypeContent typeContent = TypeContent.AddObject) where TResponse : new();
        TopTenResponse<TResponse> Get<TRequest, TResponse>(TopTenRequest request, string action) where TResponse : new();
        TopTenResponse<TResponse> Put<TRequest, TResponse>(TopTenRequest request, string action) where TResponse : new();
        TopTenResponse<TResponse> Patch<TRequest, TResponse>(TopTenRequest request, string action) where TResponse : new();
        TopTenResponse<TResponse> Delete<TRequest, TResponse>(TopTenRequest request, string action) where TResponse : new();
    }
}

