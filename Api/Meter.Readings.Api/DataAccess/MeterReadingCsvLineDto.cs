namespace Meter.Readings.Api.DataAccess;

/// <summary>
/// Represents one line of meter readings CSV
/// </summary>
public class MeterReadingCsvLineDto
{
    /// <summary>
    /// Account Id
    /// </summary>
    public int AccountId { get; set; }
    
    /// <summary>
    /// Date time of meter reading
    /// </summary>
    public DateTime MeterReadingDateTime { get; set; }
    
    /// <summary>
    /// Value of meter reading
    /// </summary>
    public string MeterReadValue { get; set; }
}