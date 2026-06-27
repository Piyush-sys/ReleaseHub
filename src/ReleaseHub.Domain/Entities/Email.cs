using System;
using System.Collections.Generic;
using System.Text;

namespace ReleaseHub.Domain.Entities;

public class Email
{
    public int Id { get; set; }

    public string Subject { get; set; } = string.Empty;

    public DateTime ReceivedOn { get; set; }
}
