using System;
using System.Collections.Generic;
using System.Text;

using ReleaseHub.Domain.Enums;

namespace ReleaseHub.Domain.Entities;

public class Server
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public CustomerType Customer { get; set; }

    public RegionType Region { get; set; }

    public EnvironmentType Environment { get; set; }

    public bool IsActive { get; set; } = true;
}
