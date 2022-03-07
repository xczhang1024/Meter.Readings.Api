namespace Meter.Readings.Api.DataAccess;

/// <summary>
/// Represents valid readings info
/// </summary>
public class ValidMeterReadingsModel
{
    /// <summary>
    /// List of valid readings for db
    /// </summary>
    public IEnumerable<MeterReadingModel> ValidMeterReadings { get; set; }
    
    /// <summary>
    /// Number of failed readings
    /// </summary>
    public int NumberOfFailedMeterReadings { get; set; }
}