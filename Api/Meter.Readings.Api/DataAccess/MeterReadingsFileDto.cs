namespace Meter.Readings.Api.DataAccess;

/// <summary>
/// Dto for file containing meter readings
/// </summary>
public class MeterReadingsFileDto
{
    /// <summary>
    /// File of meter readings
    /// </summary>
    public IFormFile MeterReadingsFile { get; set; }
}