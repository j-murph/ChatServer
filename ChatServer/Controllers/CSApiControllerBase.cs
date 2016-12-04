using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace ChatServer.Controllers
{
    public class CSApiControllerBase : ApiController
    {
        public class ApiResult
        {
            public bool Success { get; set; }
            public object Data { get; set; }
            public string ErrorCode { get; set; }

            private ApiResult()
            {
                // Disallow inheritance.
            }

            public static ApiResult FromSuccess(object data = null)
            {
                return new ApiResult
                {
                    Data = data,
                    ErrorCode = null,
                    Success = true
                };
            }

            public static ApiResult FromError(string errorCode, object data = null)
            {
                return new ApiResult
                {
                    Data = data,
                    ErrorCode = errorCode,
                    Success = false
                };
            }
        }
    }
}