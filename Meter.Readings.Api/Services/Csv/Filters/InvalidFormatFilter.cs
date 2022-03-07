using Meter.Readings.Api.DataAccess;

namespace Meter.Readings.Api.Services.Csv.Filters;

/// <summary>
/// Filter out readings which are in an invalid format
/// </summary>
public class InvalidFormatFilter : IMeterReadingsFilter
{
    /// <summary>
    /// Filter out invalid readings, leaving only valid readings
    /// </summary>
    /// <param name="meterReadings"></param>
    /// <returns></returns>
    public Task<List<MeterReadingModel>> Filter(List<MeterReadingModel> meterReadings)
    {
        return Task.FromResult(meterReadings
            .Where(reading => IsMeterReadValueValid(reading.MeterReadValue))
            .ToList());
    }
    
    /// <summary>
    /// Helper to test for validity
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    private static bool IsMeterReadValueValid(string value)
    {
        return (value.Length == 5
                && int.TryParse(value, out var iValue)
                && iValue >= 0);
    }
}