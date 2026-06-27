using Microsoft.AspNetCore.Mvc;
using ReleaseHub.Application.DTOs;
using ReleaseHub.Application.Interfaces;
using ReleaseHub.Application.DTOs;
namespace ReleaseHub.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ParserController : ControllerBase
{
    private readonly IEmailSubjectParser _parser;

    public ParserController(IEmailSubjectParser parser)
    {
        _parser = parser;
    }

    [HttpGet]
    public IActionResult Parse(string subject)
    {
        if (!_parser.TryParse(subject, out var release))
        {
            return BadRequest("Invalid release subject.");
        }

        var dto = new ReleaseDto
        {
            Version = release.Version,
            ReleaseType = release.ReleaseType.ToString(),
            Customer = release.Customer.ToString(),
            Region = release.Region.ToString(),
            ReleaseDate = release.ReleaseDate
        };

        return Ok(dto);
    }
}