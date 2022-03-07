namespace Meter.Readings.Api.DataAccess;

/// <summary>
/// Model for meter readings from Csv
/// </summary>
public class MeterReadingModel
{
    /// <summary>
    /// Acccount id
    /// </summary>
    public int AccountId { get; set; }
    
    /// <summary>
    /// Date time
    /// </summary>
    public DateTime MeterReadingDateTime { get; set; }
    
    /// <summary>
    /// Value of reading
    /// </summary>
    public string MeterReadValue { get; set; }
}