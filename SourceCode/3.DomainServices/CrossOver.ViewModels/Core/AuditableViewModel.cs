using System;
using System.ComponentModel.DataAnnotations;

namespace CrossOver.ViewModels.Core
{
    [Serializable]
    public abstract class AuditableViewModel1 : BaseViewModel
    {

        [Display(Name = "Updated On")]
        public DateTime UpdatedOn { get; set; }

        [Display(Name = "Updated By")]
        public long UpdatedBy { get; set; }

        [Display(Name = "Is Active")]
        public bool IsActive { get; set; }

    }
}
