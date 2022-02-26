using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Models.Entities
{
    public class Account : BaseEntity
    {
        public string Username { get; set; } 
        public string Password { get; set; }
        public string Email { get; set; }
        public string VerificationToken { get; set; }
        public DateTime? VerifiedAt { get; set; }
        public bool IsVerified => VerifiedAt.HasValue || ResetPasswordAt.HasValue;
        public string ResetToken { get; set; }
        public DateTime? ResetTokenExpiresAt { get; set; }
        public DateTime? ResetPasswordAt { get; set; }
        public bool? AcceptTerms { get; set; }
        public bool Inactive { get; set; } = false;
        public DateTime? DeactivatedAt { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; }
        public int StatusCode { get; set; }
        public bool IsLoggedIn { get; set; } = false;
        public bool HasMajorChanges { get; set; } = false;
        public bool? IsBlocked { get; set; }
        public DateTime? BlockedAt { get; set; }

        public List<RefreshToken> RefreshTokens { get; set; }
        public virtual List<AccountRole> Roles { get; set; } = new List<AccountRole>();
        public virtual List<MedicalInformation> MedicalInformations { get; set; } = new List<MedicalInformation>();

        public bool ownsToken(string token)
        {
            return this.RefreshTokens?.Find(x => x.Token == token) != null;
        }
    }
}
