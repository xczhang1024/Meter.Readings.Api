namespace Meter.Readings.Api.DataAccess;

public class ValidMeterReadingsModel
{
    public IEnumerable<MeterReadingModel> ValidMeterReadings { get; set; }
    
    public int NumberOfFailedMeterReadings { get; set; }
}