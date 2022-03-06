using Meter.Readings.Api.DataAccess;
using Meter.Readings.Api.Repository;

namespace Meter.Readings.Api.Services.Csv.Filters;

public class NoDuplicationFilter : IMeterReadingsFilter
{
    private readonly IMeterReadingsRepository _repository;
    
    public NoDuplicationFilter(IMeterReadingsRepository repository)
    {
        _repository = repository;
    }
    
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