using System;
using System.Collections.Generic;
using System.Text;

using ReleaseHub.Domain.Entities;

namespace ReleaseHub.Application.Interfaces;

public interface IReleaseRepository
{
    Task AddAsync(Release release);

    Task<List<Release>> GetAllAsync();
}
