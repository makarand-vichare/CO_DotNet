using CrossOver.EntityModels.Core;
using CrossOver.IRepositories.Identity;
using CrossOver.IRepositories.SearchBook;
using CrossOver.IRepositories.UserDemand;
using System;

namespace CrossOver.IRepositories.Core
{
    public interface IUnitOfWork : IDisposable
    {
        IRoleRepository RoleRepository { get; set; }
        IUserRepository UserRepository { get; set; }
        IRefreshTokenRepository RefreshTokenRepository { get; set; }
        IUserDemandRepository UserDemandRepository { get; set; }
        IBookRepository BookRepository { get; set; }


        IBaseRepository<T> SetDbContext<T>(IBaseRepository<T> repository) where T : BaseEntityModel;
    }
}
