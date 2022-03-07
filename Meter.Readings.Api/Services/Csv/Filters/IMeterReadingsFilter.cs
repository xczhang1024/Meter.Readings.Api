using Meter.Readings.Api.DataAccess;

namespace Meter.Readings.Api.Services.Csv.Filters;

/// <summary>
/// Interface for filtering meter readings
/// </summary>
public interface IMeterReadingsFilter
{
    /// <summary>
    /// Filter out invalid readings, leaving only valid readings
    /// </summary>
    /// <param name="meterReadings"></param>
    /// <returns></returns>
    Task<List<MeterReadingModel>> Filter(List<MeterReadingModel> meterReadings);
}