using CrossOver.ViewModels.Core;

namespace CrossOver.ViewModels.Identity
{
    public class UserInfoViewModel : BaseViewModel
    {
        public string Email { get; set; }

        public bool HasRegistered { get; set; }

        public string LoginProvider { get; set; }

    }

}
