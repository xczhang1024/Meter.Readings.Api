using Microsoft.AspNetCore.Mvc;

namespace Meter.Readings.Api.Services;

public interface IMeterReadingsService
{
    Task<IActionResult> ProcessReadingsFromFile(IFormFile file);
}