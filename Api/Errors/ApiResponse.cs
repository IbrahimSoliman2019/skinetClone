using System;

namespace Api.Errors
{
    public class ApiResponse
    {
        public ApiResponse(int statusCode, string message=null)
        {
            StatusCode = statusCode;
            Message = message??GetDefaultMessage(statusCode);
        }


        public int StatusCode { get; set; }
        public string Message { get; set; }
        private string GetDefaultMessage(int statusCode)
        {
            return statusCode switch{
                400=>"A bad request You have made",
                401=>"Authorized,You are not",
                404=>"Resource found ,it was not",
                501=>"there is problem in server",
                _=>null
            };
        }
    }
}