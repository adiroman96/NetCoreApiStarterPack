using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Entities
{
    public class AccountRole : BaseEntity
    {
        public long AccountID { get; set; }
        public long RoleID { get; set; }
        public DateTime createdAt { get; set; } = DateTime.Now;

        [ForeignKey("AccountID")]
        public Account Account { get; set; }
        [ForeignKey("RoleID")]
        public Role Role { get; set; }
    }
}