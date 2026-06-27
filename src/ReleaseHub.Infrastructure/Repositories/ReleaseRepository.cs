using ReleaseHub.Application.Interfaces;
using ReleaseHub.Domain.Entities;
using ReleaseHub.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace ReleaseHub.Infrastructure.Repositories;

public class ReleaseRepository : IReleaseRepository
{
    private readonly ReleaseHubDbContext _dbContext;

    public ReleaseRepository(ReleaseHubDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task AddAsync(Release release)
    {
        _dbContext.Releases.Add(release);
        await _dbContext.SaveChangesAsync();
    }
    public async Task<List<Release>> GetAllAsync()
    {
        return await _dbContext.Releases.ToListAsync();
    }
}