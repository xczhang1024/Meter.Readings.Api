using Meter.Readings.Api.DataAccess;

namespace Meter.Readings.Api.Services.Csv;

/// <summary>
/// Service for getting valid readings
/// </summary>
public interface IGetValidReadingsService
{
    /// <summary>
    /// Get valid readings from csv string
    /// </summary>
    /// <param name="meterReadings"></param>
    /// <returns></returns>
    Task<ValidMeterReadingsModel> GetValidReadings(string meterReadings);
}