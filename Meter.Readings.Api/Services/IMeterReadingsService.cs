using Microsoft.AspNetCore.Mvc;

namespace Meter.Readings.Api.Services;

public interface IMeterReadingsService
{
    IActionResult ProcessReadingsFromFile(IFormFile file);
}