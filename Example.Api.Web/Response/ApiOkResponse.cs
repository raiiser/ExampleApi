using System.Net;

namespace Example.Api.Web.Response
{
    public class ApiOkResponse : ApiResponse
    {
        public object Result { get; }

        public ApiOkResponse(object result)
            : base(HttpStatusCode.OK)
        {
            Result = result;
        }
    }
}
