using Meter.Readings.Api.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Meter.Readings.Api.Services;

public class MeterReadingsService : IMeterReadingsService
{
    private readonly IMeterReadingsRepository _repository;
    
    public MeterReadingsService(IMeterReadingsRepository repository)
    {
        _repository = repository;
    }
    
    public IActionResult ProcessReadingsFromFile(IFormFile file)
    {
        throw new NotImplementedException();
    }
}