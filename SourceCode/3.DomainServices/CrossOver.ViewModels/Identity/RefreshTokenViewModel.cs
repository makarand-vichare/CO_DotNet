using CrossOver.ViewModels.Core;
using System;
using System.ComponentModel.DataAnnotations;

namespace CrossOver.ViewModels.Identity
{
    public class RefreshTokenViewModel : BaseViewModel
    {
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
