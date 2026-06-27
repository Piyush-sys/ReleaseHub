using ReleaseHub.Application.Interfaces;
using ReleaseHub.Domain.Entities;
using ReleaseHub.Domain.Enums;

namespace ReleaseHub.Application.Services;

public class EmailSubjectParser : IEmailSubjectParser
{
    public bool TryParse(string subject, out Release release)
    {
        release = new Release();

        if (string.IsNullOrWhiteSpace(subject))
            return false;

        subject = subject.Trim();

        // Detect Release Type FIRST
        if (subject.StartsWith("Hotfix", StringComparison.OrdinalIgnoreCase))
        {
            release.ReleaseType = ReleaseType.Hotfix;
        }
        else if (subject.StartsWith("PR_", StringComparison.OrdinalIgnoreCase))
        {
            release.ReleaseType = ReleaseType.Planned;
        }
        else if (subject.StartsWith("TR_", StringComparison.OrdinalIgnoreCase))
        {
            release.ReleaseType = ReleaseType.Test;
        }
        else
        {
            return false;
        }

        // Remove Hotfix prefix after detecting release type
        subject = subject.Replace("Hotfix - ", "", StringComparison.OrdinalIgnoreCase);

        // Split subject
        var parts = subject.Split('_');

        if (parts.Length >= 4)
        {
            release.Version = parts[1];
            if (DateTime.TryParseExact(
        parts[2],
        "ddMMMyyyy",
        System.Globalization.CultureInfo.InvariantCulture,
        System.Globalization.DateTimeStyles.None,
        out var releaseDate))
            {
                release.ReleaseDate = releaseDate;
            }
            var customerRegion = parts[3];

            if (customerRegion.EndsWith("Europe", StringComparison.OrdinalIgnoreCase))
            {
                release.Region = RegionType.Europe;

                var customer = customerRegion.Replace("Europe", "");

                if (customer.Equals("Henkel", StringComparison.OrdinalIgnoreCase))
                    release.Customer = CustomerType.Henkel;
                else if (customer.Equals("BASF", StringComparison.OrdinalIgnoreCase))
                    release.Customer = CustomerType.BASF;
            }
            else if (customerRegion.EndsWith("APAC", StringComparison.OrdinalIgnoreCase))
            {
                release.Region = RegionType.APAC;

                var customer = customerRegion.Replace("APAC", "");

                if (customer.Equals("Henkel", StringComparison.OrdinalIgnoreCase))
                    release.Customer = CustomerType.Henkel;
                else if (customer.Equals("BASF", StringComparison.OrdinalIgnoreCase))
                    release.Customer = CustomerType.BASF;
            }
        }

        return true;
    }
}