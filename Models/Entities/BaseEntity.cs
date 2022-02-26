using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Entities
{
    public class BaseEntity : IObjectWithStatusCode
    {
        public long Id { get; set; }
        public int StatusCode { get; set; }
    }
}
