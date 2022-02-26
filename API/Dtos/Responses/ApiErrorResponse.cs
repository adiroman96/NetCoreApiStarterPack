using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class ApiErrorResponse<T> : ApiResponse<T> where T : class 
    {
        public int ErrorCode { get; set; } = (int)ErrorCodes.Undefined;
        public List<ErrorResponse> Errors { get; set; } = new List<ErrorResponse>();

        public ApiErrorResponse(int statusCode = 400, string message = null, T data = null, int errorCode = (int)ErrorCodes.Undefined, List<ErrorResponse> errors = null) : base(statusCode, message, data) 
        {
            ErrorCode = errorCode;
            if(errors != null)
            {
                Errors = errors;
            }
        }
    }
}
