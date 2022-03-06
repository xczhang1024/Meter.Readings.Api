using Meter.Readings.Api.DataAccess;
using Meter.Readings.Api.Repository;
using Meter.Readings.Api.Services.Csv;
using Microsoft.AspNetCore.Mvc;

namespace Meter.Readings.Api.Services;

public class MeterReadingsService : IMeterReadingsService
{
    private readonly IMeterReadingsRepository _repository;

    private readonly IFileReader _fileReader;

    private readonly IGetValidReadingsService _getValidReadingsService;
    
    public MeterReadingsService(IMeterReadingsRepository repository, 
        IFileReader fileReader, 
        IGetValidReadingsService getValidReadingsService)
    {
        _repository = repository;
        _fileReader = fileReader;
        _getValidReadingsService = getValidReadingsService;
    }
    
    public async Task<IActionResult> ProcessReadingsFromFile(IFormFile file)
    {
        try
        {
            var fileContents = await _fileReader.ReadFileToString(file);

            if (!string.IsNullOrWhiteSpace(fileContents))
            {
                var validReadingsModel = await _getValidReadingsService.GetValidReadings(fileContents);
                await _repository.AddMeterReadings(validReadingsModel.ValidMeterReadings);

                return new OkObjectResult(new SuccessDto()
                {
                    NumberOfProcessedRecords = validReadingsModel.ValidMeterReadings.Count(),
                    NumberOfFailedRecords = validReadingsModel.NumberOfFailedMeterReadings
                });
            }

            return new EmptyResult();
        }
        catch (Exception e)
        {
            return new BadRequestObjectResult(new ErrorDto()
            {
                Message = "Failed to process meter readings",
                ExceptionMessage = e.Message
            });
        }
    }
}