
namespace TopTenAPI.Common
{
    public class ApiResponse<T>
    {
        public ApiResponse()
        {
        }

        public T Data { get; set; }
        public bool Success { get; set; }
        public ApiError Error { get; set;}

        public ApiResponse(bool success, T data, string errMsg= null)
        {
            Data = data;
            Success = success;
            if (!string.IsNullOrEmpty(errMsg)) Error = new ApiError(errMsg);
        }
    }

    public class ApiError
    {
        public string Message { get; set; }
        public ApiError()
        {
        }

        public ApiError(string errMsg)
        {
            Message = errMsg;
        }
    }
}