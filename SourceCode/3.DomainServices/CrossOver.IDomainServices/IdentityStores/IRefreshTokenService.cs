using CrossOver.EntityModels.Identity;
using CrossOver.IDomainServices.Core;
using CrossOver.ViewModels.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CrossOver.IDomainServices.IdentityStores
{
    public interface IRefreshTokenService : IBaseService<RefreshTokenEntityModel, RefreshTokenViewModel>
    {
        Task<bool> AddRefreshToken(RefreshTokenViewModel token);
        Task<bool> RemoveRefreshToken(string refreshTokenId);
        Task<bool> RemoveRefreshToken(RefreshTokenViewModel refreshToken);
        Task<RefreshTokenViewModel> FindRefreshToken(string refreshTokenId);
        List<RefreshTokenViewModel> GetAllRefreshTokens();
    }
}
