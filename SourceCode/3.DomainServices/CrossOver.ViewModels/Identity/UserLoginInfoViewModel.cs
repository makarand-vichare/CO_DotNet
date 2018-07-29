using CrossOver.ViewModels.Core;

namespace CrossOver.ViewModels.Identity
{
    public class UserLoginInfoViewModel : BaseViewModel
    {
        public string LoginProvider { get; set; }

        public string ProviderKey { get; set; }
    }
}
