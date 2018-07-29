using CrossOver.EntityModels.Core;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace CrossOver.EntityModels.Identity
{

    public class UserEntityModel : BaseEntityModel
    {
        
        #region Fields
        private ICollection<ClaimEntityModel> _claims;
        private ICollection<RoleEntityModel> _roles;
        #endregion

        #region Scalar Properties
        public string UserName { get; set; }

        public virtual string PasswordHash { get; set; }
        public virtual string SecurityStamp { get; set; }
        #endregion

        #region Navigation Properties
        [BsonIgnore]
        public virtual ICollection<ClaimEntityModel> Claims
        {
            get { return _claims ?? (_claims = new List<ClaimEntityModel>()); }
            set { _claims = value; }
        }

        [BsonIgnore]
        public virtual ICollection<RoleEntityModel> Roles
        {
            get { return _roles ?? (_roles = new List<RoleEntityModel>()); }
            set { _roles = value; }
        }

        #endregion
    }
}
