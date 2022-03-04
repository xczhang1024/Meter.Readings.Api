using Meter.Readings.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace Meter.Readings.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MeterReadingsController : ControllerBase
{
    /// <summary>
    /// The service
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
}