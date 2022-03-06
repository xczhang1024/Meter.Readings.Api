namespace Meter.Readings.Api.DataAccess;

public class SuccessDto
{
    public int NumberOfProcessedRecords { get; set; }
    
    public int NumberOfFailedRecords { get; set; }
}