using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReleaseHub.Domain.Entities;
using ReleaseHub.Domain.Enums;
using ReleaseHub.Infrastructure.Persistence;

namespace ReleaseHub.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ReleaseController : ControllerBase
{
    private readonly ReleaseHubDbContext _context;

    public ReleaseController(ReleaseHubDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var releases = await _context.Releases.ToListAsync();
        return Ok(releases);
    }

    [HttpPost]
    public async Task<IActionResult> Create()
    {
        var release = new Release
        {
            Version = "V6.3.60.06",
            ReleaseType = ReleaseType.Hotfix,
            Environment = EnvironmentType.Production,
            Customer = CustomerType.Henkel,
            Region = RegionType.Europe,
            ReleaseDate = DateTime.Now,
            IsSuccess = true,
            CreatedOn = DateTime.Now
        };

        _context.Releases.Add(release);

        await _context.SaveChangesAsync();

        return Ok(release);
    }
}