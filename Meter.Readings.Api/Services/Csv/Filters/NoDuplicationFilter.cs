using Meter.Readings.Api.DataAccess;
using Meter.Readings.Api.Repository;

namespace Meter.Readings.Api.Services.Csv.Filters;

/// <summary>
/// Filter out all readings which already exist in the db
/// </summary>
public class NoDuplicationFilter : IMeterReadingsFilter
{
    /// <summary>
    /// Repository
    /// </summary>
    private readonly IMeterReadingsRepository _repository;
    
    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="repository"></param>
    public NoDuplicationFilter(IMeterReadingsRepository repository)
    {
        _repository = repository;
    }
    
    /// <summary>
    /// Filter out invalid readings, leaving only valid readings
    /// </summary>
    /// <param name="meterReadings"></param>
    /// <returns></returns>
    public async Task<List<MeterReadingModel>> Filter(List<MeterReadingModel> meterReadings)
    {
        var readings = new List<MeterReadingModel>();
        
        foreach (var reading in meterReadings)
        {
            var existingReading = await _repository.GetMeterReading(reading.AccountId,
                reading.MeterReadingDateTime,
                reading.MeterReadValue);

            if (existingReading == null)
            {
                readings.Add(reading);
            }
        }

        return readings;
    }
}