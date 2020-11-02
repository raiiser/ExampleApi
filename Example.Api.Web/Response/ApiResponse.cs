using Newtonsoft.Json;
using System;
using System.Net;

namespace Example.Api.Web.Response
{
    public class ApiResponse
    {
        public HttpStatusCode StatusCode { get; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Message { get; }

        public ApiResponse(HttpStatusCode statusCode, string message = null)
        {
            StatusCode = statusCode;
            Message = message ?? GetDefaultMessageForStatusCode(statusCode);
        }

        public ApiResponse(HttpStatusCode statusCode, Exception exception)
        {
            StatusCode = statusCode;
            Message = exception.Message ?? GetDefaultMessageForStatusCode(statusCode);
        }

        private static string GetDefaultMessageForStatusCode(HttpStatusCode statusCode)
        {
            switch (statusCode)
            {
                case HttpStatusCode.BadRequest:
                    return "Erreur";
                case HttpStatusCode.NotFound:
                    return "Resource non trouvée";
                case HttpStatusCode.InternalServerError:
                    return "Erreur technique";
                default:
                    return null;
            }
        }
    }
}
