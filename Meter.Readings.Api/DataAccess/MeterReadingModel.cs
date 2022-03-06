namespace Meter.Readings.Api.DataAccess;

public class MeterReadingModel
{
    public int AccountId { get; set; }
    
    public DateTime MeterReadingDateTime { get; set; }
    
    public string MeterReadValue { get; set; }
}