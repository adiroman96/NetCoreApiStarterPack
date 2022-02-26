using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Entities
{
    public class Role : BaseEntity
    {
        public enum mappings
        {
            Admin = 1,
            Doctor = 2,
            Pacient = 3,
            Contributor = 4
        }

        public string Name { get; set; }
        public int Mapping { get; set; }
    }
}
