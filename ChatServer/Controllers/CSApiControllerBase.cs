using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace ChatServer.Controllers
{
    public class CSApiControllerBase : ApiController
    {
        /// <summary>
        /// Validate model state helper method.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Val<T>(T model)
        {
            return model != null && ModelState.IsValid;
        }

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

            public static ApiResult BadRequest
            {
                get
                {
                    return new ApiResult
                    {
                        ErrorCode = "invalid-request",
                        Success = false
                    };
                }
            }

            public static ApiResult Okay
            {
                get
                {
                    return new ApiResult
                    {
                        Success = true
                    };
                }
            }
        }
    }
}