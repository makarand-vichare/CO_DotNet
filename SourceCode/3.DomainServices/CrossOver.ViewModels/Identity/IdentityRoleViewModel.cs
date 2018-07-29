using CrossOver.ViewModels.Core;
using Microsoft.AspNet.Identity;
using MongoDB.Bson;

namespace CrossOver.ViewModels.Identity
{
    public class IdentityRoleViewModel : BaseViewModel, IRole<ObjectId>
    {

        public IdentityRoleViewModel(string name)
        {
            this.Name = name;
        }

        public IdentityRoleViewModel(string name, ObjectId id)
        {
            this.Name = name;
            this.Id = id;
        }

        public string Name { get; set; }
    }
}
