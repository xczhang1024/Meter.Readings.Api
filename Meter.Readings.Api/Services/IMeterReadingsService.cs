using Microsoft.AspNetCore.Mvc;

namespace Meter.Readings.Api.Services;

/// <summary>
/// Service for api controller
/// </summary>
public interface IMeterReadingsService
{
    /// <summary>
    /// Process readings from file
    /// </summary>
    /// <param name="file"></param>
    /// <returns></returns>
    Task<IActionResult> ProcessReadingsFromFile(IFormFile file);
}