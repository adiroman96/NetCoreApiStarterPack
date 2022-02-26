using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class ApiResponse<T> where T : class
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }

        public ApiResponse(int statusCode = 200, string message = null, T data = null)
        {
            StatusCode = statusCode;
            Message = message ?? GetDefaultMessageForStatusCode(statusCode);
            Data = data;
        }

        protected string GetDefaultMessageForStatusCode(int statusCode)
        {
            return statusCode switch
            {
                200 => "Operatiune efectuata cu succes",
                400 => "Ceva nu a mers bine. Verificati datele introduse.",
                401 => "Nu sunteti autentificat.",
                404 => "Nu s-a gasit resursa dorita",
                403 => "Nu aveti dreptul sa efectuati aceasta operatiune.",
                500 => "A aparut o eroare pe server",
                _ =>    null
            };
        }       
    }
}
