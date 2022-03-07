namespace Meter.Readings.Api.DataAccess;

/// <summary>
/// Success result returned from Api
/// </summary>
public class SuccessDto
{
    /// <summary>
    /// Number of successful records
    /// </summary>
    public int NumberOfProcessedRecords { get; set; }
    
    /// <summary>
    /// Number of failed records
    /// </summary>
    public int NumberOfFailedRecords { get; set; }
}