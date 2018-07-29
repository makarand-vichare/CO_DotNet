using System.ComponentModel.Composition;
using CrossOver.Common.MEF;
using CrossOver.Repositories.Core;
using CrossOver.IRepositories.Core;
using CrossOver.Repositories.Identity;
using CrossOver.IRepositories.Identity;
using MongoDB.Driver;
using System.Configuration;
using CrossOver.Repositories.SearchBook;
using CrossOver.IRepositories.SearchBook;
using CrossOver.IRepositories.UserDemand;
using CrossOver.Repositories.UserDemand;

namespace CrossOver.Repositories
{
    [Export(typeof(IModule))]
    public class ModuleInit : IModule
    {
        public void Initialize(IModuleRegistrar registrar)
        {
            registrar.RegisterType<IBookRepository, BookRepository>();
            registrar.RegisterType<IUserDemandRepository, UserDemandRepository>();
            registrar.RegisterType<IUnitOfWork, UnitOfWork>();
            registrar.RegisterType<IUserRepository, UserRepository>();
            registrar.RegisterType<IRoleRepository, RoleRepository>();
            registrar.RegisterType<IRefreshTokenRepository, RefreshTokenRepository>();
            registrar.RegisterType(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            registrar.RegisterType<IMongoClient, MongoClient>(ConfigurationManager.ConnectionStrings["MongoDbConnection"].ConnectionString);
            registrar.RegisterInstanceSingleton(typeof(IMongoDatabase),DataSeeder.GetDataBase());
            
        }
    }
}
