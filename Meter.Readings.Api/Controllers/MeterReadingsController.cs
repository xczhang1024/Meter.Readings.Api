using Meter.Readings.Api.DataAccess;
using Meter.Readings.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace Meter.Readings.Api.Controllers;

/// <summary>
/// Meter readings Api controller
/// </summary>
[ApiController]
public class MeterReadingsController : ControllerBase
{
    /// <summary>
    /// Meter readings service
    /// </summary>
    private readonly IMeterReadingsService _service;
    
    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="service"></param>
    public MeterReadingsController(IMeterReadingsService service)
    {
        _service = service;
    }
    
    /// <summary>
    /// Endpoint to upload readings file
    /// </summary>
    /// <param name="fileDto"></param>
    /// <returns></returns>
    [HttpPost]
    [Route("meter-reading-uploads")]
    public async Task<IActionResult> UploadReadingsFile([FromForm] MeterReadingsFileDto fileDto)
    {
        return await _service.ProcessReadingsFromFile(fileDto.File);
    }
}