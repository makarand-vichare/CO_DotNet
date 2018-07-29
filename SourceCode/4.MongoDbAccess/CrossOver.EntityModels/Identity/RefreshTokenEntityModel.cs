using CrossOver.EntityModels.Core;
using System;
using System.ComponentModel.DataAnnotations;

namespace CrossOver.EntityModels.Identity
{
    public class RefreshTokenEntityModel : BaseEntityModel
    {
        [Required]
        public string TokenId { get; set; }
        [Required]
        [MaxLength(50)]
        public string Subject { get; set; }
        public DateTime IssuedUtc { get; set; }
        public DateTime ExpiresUtc { get; set; }
        [Required]
        public string ProtectedTicket { get; set; }
    }
}
