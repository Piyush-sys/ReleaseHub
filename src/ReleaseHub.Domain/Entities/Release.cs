using System;
using System.Collections.Generic;
using System.Text;
using ReleaseHub.Domain.Enums;
namespace ReleaseHub.Domain.Entities;
public class Release
{
    public int Id { get; set; }

    public string Version { get; set; } = string.Empty;

    public ReleaseType ReleaseType { get; set; }

    public EnvironmentType Environment { get; set; }

    public CustomerType Customer { get; set; }

    public RegionType Region { get; set; }

    public int ServerId { get; set; }

    public Server? Server { get; set; }

    public int EmailId { get; set; }

    public Email? Email { get; set; }

    public DateTime ReleaseDate { get; set; }

    public bool IsSuccess { get; set; }

    public DateTime CreatedOn { get; set; } = DateTime.UtcNow;

    public DateTime? UpdatedOn { get; set; }
}