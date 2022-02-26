using API.Helpers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Extensions
{
    public static class ResponseExtension
    {
        public static string Serialize(this object obj)
        {
            try
            {
                var x = JsonConvert.SerializeObject(obj, new JsonSerializerSettings
                {
                    ContractResolver = new SubstituteNullWithEmptyStringContractResolver(),
                    ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore,
                    NullValueHandling = NullValueHandling.Include,
                });
                return x;
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}
