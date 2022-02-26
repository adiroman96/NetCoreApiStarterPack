using Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Extensions
{
    public static class StatusCodeExtensions
    {
        public static int GetInt(this StatusCode status)
        {
            return (int)status;
        }

        public static bool IsActive(this IObjectWithStatusCode obj)
        {
            return obj.StatusCode == StatusCode.Active.GetInt();
        }

        public static bool IsTerminated(this IObjectWithStatusCode obj)
        {
            return obj.StatusCode == StatusCode.Terminated.GetInt();
        }
    }
}
