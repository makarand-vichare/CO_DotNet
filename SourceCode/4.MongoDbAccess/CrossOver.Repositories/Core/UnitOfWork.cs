using CrossOver.EntityModels.Core;
using CrossOver.IRepositories.Core;
using CrossOver.IRepositories.Identity;
using CrossOver.IRepositories.SearchBook;
using CrossOver.IRepositories.UserDemand;
using MongoDB.Driver;
using StructureMap.Attributes;
using System;

namespace CrossOver.Repositories.Core
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private IMongoDatabase database;
        private IRefreshTokenRepository refreshTokenRepository;
        private IRoleRepository roleRepository;
        private IUserRepository userRepository;

        private IUserDemandRepository userDemandRepository;
        private IBookRepository bookRepository;

        public UnitOfWork(IMongoDatabase database)
        {
            this.database = database;
        }

        [SetterProperty]
        public IRefreshTokenRepository RefreshTokenRepository
        {
            get { return refreshTokenRepository; }
            set
            {
                refreshTokenRepository = value;
                refreshTokenRepository.Database = database;
            }
        }

        [SetterProperty]
        public IRoleRepository RoleRepository
        {
            get { return roleRepository; }
            set
            {
                roleRepository = value;
                roleRepository.Database = database;
            }
        }

        [SetterProperty]
        public IUserRepository UserRepository
        {
            get { return userRepository; }
            set
            {
                userRepository = value;
                userRepository.Database = database;
            }
        }

        [SetterProperty]
        public IUserDemandRepository UserDemandRepository
        {
            get { return userDemandRepository; }
            set
            {
                userDemandRepository = value;
                userDemandRepository.Database = database;
            }
        }

        [SetterProperty]
        public IBookRepository BookRepository
        {
            get { return bookRepository; }
            set
            {
                bookRepository = value;
                bookRepository.Database = database;
            }
        }

        public IBaseRepository<T> SetDbContext<T>(IBaseRepository<T> repository) where T : BaseEntityModel
        {
            repository.Database = database;
            return repository;
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
