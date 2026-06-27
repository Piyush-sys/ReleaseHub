using System;
using System.Collections.Generic;
using System.Text;

namespace ReleaseHub.Application.DTOs;

public class ReleaseDto
{
    public string Version { get; set; } = string.Empty;

    public string ReleaseType { get; set; } = string.Empty;

    public string Customer { get; set; } = string.Empty;

    public string Region { get; set; } = string.Empty;

    public DateTime ReleaseDate { get; set; }
}
