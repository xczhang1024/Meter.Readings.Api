using Meter.Readings.Api.DataAccess;
using Meter.Readings.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace Meter.Readings.Api.Controllers;

[ApiController]
public class MeterReadingsController : ControllerBase
{
    private readonly IMeterReadingsService _service;
    
    public MeterReadingsController(IMeterReadingsService service)
    {
        _service = service;
    }
    
    [HttpPost]
    [Route("meter-reading-uploads")]
    public IActionResult UploadReadingsFile(MeterReadingsFileDto fileDto)
    {
        _service.ProcessReadingsFromFile(fileDto.File);
        return Ok();
    }
}