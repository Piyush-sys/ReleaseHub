using ReleaseHub.Application.Services;
using ReleaseHub.Domain.Enums;

namespace ReleaseHub.Tests;

public class EmailSubjectParserTests
{
    [Fact]
    public void TryParse_Should_Detect_Hotfix()
    {
        // Arrange
        var parser = new EmailSubjectParser();

        // Act
        var result = parser.TryParse(
            "Hotfix - PR_V6.3.60.06_26Jun2026_HenkelEurope",
            out var release);

        // Assert
        Assert.True(result);
        Assert.Equal(ReleaseType.Hotfix, release.ReleaseType);
    }
    [Fact]
    public void TryParse_Should_Detect_Planned_Release()
    {
        // Arrange
        var parser = new EmailSubjectParser();

        // Act
        var result = parser.TryParse(
            "PR_V6.3.60.01_19May2026_HenkelEurope",
            out var release);

        // Assert
        Assert.True(result);
        Assert.Equal(ReleaseType.Planned, release.ReleaseType);
    }
    [Fact]
    public void TryParse_Should_Detect_Test_Release()
    {
        // Arrange
        var parser = new EmailSubjectParser();

        // Act
        var result = parser.TryParse(
            "TR_V6.3.61.00_27May2026_HenkelAPAC",
            out var release);

        // Assert
        Assert.True(result);
        Assert.Equal(ReleaseType.Test, release.ReleaseType);
    }
    [Fact]
    public void TryParse_Should_Extract_Version()
    {
        // Arrange
        var parser = new EmailSubjectParser();

        // Act
        parser.TryParse(
            "PR_V6.3.60.01_19May2026_HenkelEurope",
            out var release);

        // Assert
        Assert.Equal("V6.3.60.01", release.Version);
    }
    [Fact]
    public void TryParse_Should_Extract_Customer()
    {
        var parser = new EmailSubjectParser();

        parser.TryParse(
            "PR_V6.3.60.01_19May2026_HenkelEurope",
            out var release);

        Assert.Equal(CustomerType.Henkel, release.Customer);
    }
    [Fact]
    public void TryParse_Should_Extract_Region()
    {
        var parser = new EmailSubjectParser();

        parser.TryParse(
            "PR_V6.3.60.01_19May2026_HenkelEurope",
            out var release);

        Assert.Equal(RegionType.Europe, release.Region);
    }
    [Fact]
    public void TryParse_Should_Extract_ReleaseDate()
    {
        var parser = new EmailSubjectParser();

        parser.TryParse(
            "PR_V6.3.60.01_19May2026_HenkelEurope",
            out var release);

        Assert.Equal(new DateTime(2026, 5, 19), release.ReleaseDate);
    }
}