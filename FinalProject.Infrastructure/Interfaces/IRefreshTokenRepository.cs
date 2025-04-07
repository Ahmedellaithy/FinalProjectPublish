using FinalProject.Data.Models.Authentication;
using FinalProject.Infrastructure.GenericRepositories;

namespace FinalProject.Infrastructure.Interfaces;

public interface IRefreshTokenRepository : IGenericRepository<RefereshToken>
{
    Task<RefereshToken> GetRefreshTokenByIdAsync(int refreshTokenId);
}