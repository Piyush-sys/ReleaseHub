using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.EntityFrameworkCore;
using ReleaseHub.Domain.Entities;

namespace ReleaseHub.Infrastructure.Persistence;

public class ReleaseHubDbContext : DbContext
{
    public ReleaseHubDbContext(DbContextOptions<ReleaseHubDbContext> options)
        : base(options)
    {
    }

    public DbSet<Release> Releases => Set<Release>();

    public DbSet<Server> Servers => Set<Server>();

    public DbSet<Email> Emails => Set<Email>();
}
