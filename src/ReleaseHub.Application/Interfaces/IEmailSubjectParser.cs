using ReleaseHub.Domain.Entities;

namespace ReleaseHub.Application.Interfaces;

public interface IEmailSubjectParser
{
    bool TryParse(string subject, out Release release);
}