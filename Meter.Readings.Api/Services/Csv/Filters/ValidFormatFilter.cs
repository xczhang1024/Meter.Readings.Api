using Meter.Readings.Api.DataAccess;

namespace Meter.Readings.Api.Services.Csv.Filters;

public class ValidFormatFilter : IMeterReadingsFilter
{
    public Task<List<MeterReadingModel>> Filter(List<MeterReadingModel> meterReadings)
    {
        return Task.FromResult(meterReadings
            .Where(reading => IsMeterReadValueValid(reading.MeterReadValue))
            .ToList());
    }
    
    private static bool IsMeterReadValueValid(string value)
    {
        return (value.Length == 5
                && int.TryParse(value, out var iValue)
                && iValue > 0);
    }
}