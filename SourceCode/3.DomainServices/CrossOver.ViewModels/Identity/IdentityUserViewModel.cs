using CrossOver.ViewModels.Core;
using Microsoft.AspNet.Identity;
using MongoDB.Bson;
using System.Collections.Generic;

namespace CrossOver.ViewModels.Identity
{

    public class IdentityUserViewModel : BaseViewModel, IUser<ObjectId>
    {
        public IdentityUserViewModel()
        {

        }
        public IdentityUserViewModel(string userName)
        {
            this.UserName = userName;
        }

        public string UserName { get; set; }
        public virtual string PasswordHash { get; set; }
        public virtual string SecurityStamp { get; set; }
        public string InputPassword { get; set; }

        public IEnumerable<UserLoginInfoViewModel> Logins { get; set; }

    }
}
