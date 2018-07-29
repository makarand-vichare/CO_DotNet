using CrossOver.IRepositories.Core;
using CrossOver.Tests.Common.MockRepositories;
using CrossOver.Tests.DomainServices.MockRepositories;
using Moq;

namespace CrossOver.Tests.Common
{
    public class UnitOfWorkGenerator
    {
        public static IUnitOfWork MockUnitOfWork()
        {
            Mock<IUnitOfWork> mockUnitOfWork = new Mock<IUnitOfWork>(MockBehavior.Strict);
            mockUnitOfWork.SetupProperty(a => a.UserRepository, UserRepositoryGenerator.GetMockRepository().Object);
            mockUnitOfWork.SetupProperty(a => a.BookRepository, BookRepositoryGenerator.GetMockRepository().Object);
            mockUnitOfWork.SetupProperty(a => a.UserDemandRepository, UserDemandRepositoryGenerator.GetMockRepository().Object);

            return mockUnitOfWork.Object;
        }
    }
}
