using Meter.Readings.Api.DataAccess;
using Meter.Readings.Api.Repository;
using Meter.Readings.Api.Services.Csv;
using Microsoft.AspNetCore.Mvc;

namespace Meter.Readings.Api.Services;

/// <summary>
/// Service for api controller
/// </summary>
public class MeterReadingsService : IMeterReadingsService
{
    /// <summary>
    /// Repository
    /// </summary>
    private readonly IMeterReadingsRepository _repository;

    /// <summary>
    /// File reader
    /// </summary>
    private readonly IFileReader _fileReader;

    /// <summary>
    /// Service for getting valid readings
    /// </summary>
    private readonly IGetValidReadingsService _getValidReadingsService;
    
    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="repository"></param>
    /// <param name="fileReader"></param>
    /// <param name="getValidReadingsService"></param>
    public MeterReadingsService(IMeterReadingsRepository repository, 
        IFileReader fileReader, 
        IGetValidReadingsService getValidReadingsService)
    {
        _repository = repository;
        _fileReader = fileReader;
        _getValidReadingsService = getValidReadingsService;
    }
    
    /// <summary>
    /// Process readings from file
    /// </summary>
    /// <param name="file"></param>
    /// <returns></returns>
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