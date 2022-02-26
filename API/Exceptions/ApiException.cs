using API.Dtos;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace API.Exceptions
{
    public class ApiException : Exception
    {
        public int StatusCode { get; set; } = (int)HttpStatusCode.BadRequest;
        public int ErrorCode { get; set; } = (int)ErrorCodes.Undefined;
        public string Message { get; set; }
        public List<ErrorResponse> Errors { get; set; } = new List<ErrorResponse>();

        public ApiException() : base()
        {

        }

        public ApiException(
            int statusCode = (int)HttpStatusCode.BadRequest,
            string message = "",
            int errorCode = (int)ErrorCodes.Undefined,
            List<ErrorResponse> errors = null)
        {
            StatusCode = statusCode;
            Message = message;
            ErrorCode = errorCode;
            Errors = errors ?? new List<ErrorResponse>();
        }
    }
}
