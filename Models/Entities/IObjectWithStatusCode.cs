using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models.Entities
{
    public interface IObjectWithStatusCode
    {
        [Key]
        public long Id { get; set; }

        public int StatusCode { get; set; }
    }
}
