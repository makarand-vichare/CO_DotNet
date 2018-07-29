using CrossOver.DomainServices.Core;
using CrossOver.EntityModels.Identity;
using CrossOver.IDomainServices.AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using CrossOver.IDomainServices.IdentityStores;
using System;
using CrossOver.InfraStructure.Logging;
using CrossOver.ViewModels.Identity;

namespace CrossOver.DomainServices.IdentityStores
{
    public class RefreshTokenService : BaseService<RefreshTokenEntityModel, RefreshTokenViewModel> , IRefreshTokenService
    {
        public async Task<bool> AddRefreshToken(RefreshTokenViewModel token)
        {
            var existingToken = UnitOfWork.RefreshTokenRepository.Get(r => r.Subject == token.Subject);
            if (existingToken != null)
            {
                var result = await RemoveRefreshToken(existingToken.TokenId);
            }

            var tokenEntity = token.ToEntityModel<RefreshTokenEntityModel, RefreshTokenViewModel>();
            try
            {
                await UnitOfWork.RefreshTokenRepository.AddAsync(tokenEntity);
                return true;
            }
            catch (Exception ex)
            {
                NLogLogger.Instance.Log(ex);
                return false;
            }
        }

        public async Task<bool> RemoveRefreshToken(string refreshTokenId)
        {
            var refreshToken = await UnitOfWork.RefreshTokenRepository.FindByTokenIdAsync(refreshTokenId);
            if (refreshToken != null)
            {
                try
                {
                    await UnitOfWork.RefreshTokenRepository.DeleteAsync(refreshToken);
                    return true;
                }
                catch (Exception ex)
                {
                    NLogLogger.Instance.Log(ex);
                    return false;
                }
            }

            return false;
        }

        public async Task<bool> RemoveRefreshToken(RefreshTokenViewModel refreshToken)
        {
            var tokenEntity = refreshToken.ToEntityModel<RefreshTokenEntityModel, RefreshTokenViewModel>();
             await UnitOfWork.RefreshTokenRepository.DeleteAsync(tokenEntity);
            return true;
        }

        public async Task<RefreshTokenViewModel> FindRefreshToken(string refreshTokenId)
        {
            var refreshToken = await UnitOfWork.RefreshTokenRepository.FindByTokenIdAsync(refreshTokenId);
            var tokenViewModel = refreshToken.ToViewModel<RefreshTokenEntityModel, RefreshTokenViewModel>();
            return tokenViewModel;
        }

        public List<RefreshTokenViewModel> GetAllRefreshTokens()
        {
            return UnitOfWork.RefreshTokenRepository
                .GetAll()
                .ToViewModel<RefreshTokenEntityModel, RefreshTokenViewModel>()
                .ToList();
        }
    }
}
