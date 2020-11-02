using System;
using System.Net;

namespace Example.Api.Web.Response
{
    public class ApiErrorResponse : ApiResponse
    {
        public string Type { get; set; }
        public string StackTrace { get; set; }

        public ApiErrorResponse(HttpStatusCode code, Exception ex)
            :base(code, ex.Message)
        {
            Type = ex.GetType().Name;
            StackTrace = ex.ToString();
        }
    }
}
