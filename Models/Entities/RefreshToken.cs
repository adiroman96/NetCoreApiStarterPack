using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Entities
{
    public class RefreshToken : BaseEntity
    {
        public long AccountID { get; set; }
        public string Token { get; set; }
        public DateTime ExpiresAt { get; set; }
        public bool IsExpired => DateTime.Now >= ExpiresAt;
        public string CreatedByIp { get; set; }
        public DateTime? Revoked { get; set; }
        public string RevokedByIp { get; set; }
        public string ReplacedByToken { get; set; }
        public bool IsActive => Revoked == null && !IsExpired;
        public DateTime CreatedAt { get; set; }
        public int StatusCode { get; set; }

        [ForeignKey("AccountID")]
        public Account Account { get; set; }
    }
}