using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Extensions
{
    public static class ObjectExtension
    {
        public static bool IsNullOrEmpty(this object obj)
        {
            return (obj == null || obj.ToString() == string.Empty);
        }


    }
}
