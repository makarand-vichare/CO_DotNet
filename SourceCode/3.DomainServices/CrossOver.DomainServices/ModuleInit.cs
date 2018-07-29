using CrossOver.Common.MEF;
using CrossOver.DomainServices.IdentityStores;
using CrossOver.IDomainServices.IdentityStores;
using CrossOver.IDomainServices.Services;
using CrossOver.ViewModels.Identity;
using Microsoft.AspNet.Identity;
using MongoDB.Bson;
using System.ComponentModel.Composition;

namespace CrossOver.DomainServices
{
    [Export(typeof(IModule))]
    public class ModuleInit : IModule
    {
        public void Initialize(IModuleRegistrar registrar)
        {
            registrar.RegisterType<ISearchBookService, SearchBookService>();
            registrar.RegisterType<IUserDemandService, UserDemandService>();
            registrar.RegisterType(typeof(IUserStore<IdentityUserViewModel, ObjectId>), typeof(CustomUserStore));
            registrar.RegisterType(typeof(IRoleStore<IdentityRoleViewModel, ObjectId>) , typeof(CustomRoleStore));
            registrar.RegisterType<IRefreshTokenService, RefreshTokenService>();
        }
    }
}
