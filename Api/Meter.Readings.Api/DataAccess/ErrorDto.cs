namespace Meter.Readings.Api.DataAccess;

/// <summary>
/// Error dto
/// </summary>
public class ErrorDto
{
    /// <summary>
    /// Error message
    /// </summary>
    public string Message { get; set; }
    
    /// <summary>
    /// Exception message
    /// </summary>
    public string ExceptionMessage { get; set; }
}