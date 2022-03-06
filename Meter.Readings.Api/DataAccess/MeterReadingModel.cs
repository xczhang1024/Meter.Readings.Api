namespace Meter.Readings.Api.DataAccess;

/// <summary>
/// Represents one meter reading
/// </summary>
public class MeterReadingModel
{
    public int AccountId { get; set; }
    
    public DateTime MeterReadingDateTime { get; set; }
    
    public string MeterReadValue { get; set; }
}