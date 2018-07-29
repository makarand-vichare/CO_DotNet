using CrossOver.ViewModels.Core;
using System.Collections.Generic;

namespace CrossOver.ViewModels.Identity
{
    public class ManageInfoViewModel : BaseViewModel
    {
        public string LocalLoginProvider { get; set; }

        public string Email { get; set; }

        public IEnumerable<UserLoginInfoViewModel> Logins { get; set; }

    }

}
