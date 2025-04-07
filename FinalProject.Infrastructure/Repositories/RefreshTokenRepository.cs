using FinalProject.Data.Models.Authentication;
using FinalProject.Infrastructure.Context;
using FinalProject.Infrastructure.GenericRepositories;
using FinalProject.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FinalProject.Infrastructure.Repositories;

public class RefreshTokenRepository : GenericRepository<RefereshToken>,
                                      IRefreshTokenRepository
{
    
    private readonly DbSet<RefereshToken> _token;
    public RefreshTokenRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
        _token = dbContext.Set<RefereshToken>();
    }
    

    public async Task<RefereshToken> GetRefreshTokenByIdAsync(int refreshTokenId)
    {
        var token = await _token.AsNoTracking()
            .Include(x => x.UserId)
            .Where(x => x.Id == refreshTokenId).SingleOrDefaultAsync();
        
        return token;
    }
}